using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO;

namespace WorkPlus {

    public class ScreenCapture : MonoBehaviour {

        /// <summary>
        /// Add this component to any obejct and set options in inspector to use.
        /// 
        /// The saved image file name is current date and time.
        /// If it's Snapshot mode, it will create folder and save image in that folder.
        /// If it's Debug mode, Image and Text both of names are be Text Log. (limit 40 words)
        ///     If text won't be saved, image' name is current date and time.
        /// 
        /// If you don't use UpdateManager class, Remove 'UpdateManager.Updater += KeyPressed' in Awake Method.
        /// If you don't use LocalInvoke method in Extension script, replace it with coroutine.
        /// </summary>
         
        public enum Extension { PNG, JPG }
        public enum Mode { Screenshot, Snapshot, Debug }

        /* Inspector Elements */
        public Mode mode = Mode.Screenshot;
        public KeyCode captureKey;
        public Extension extension = Extension.PNG;
        public int quality = 75; //JPG property
        public int frame = 3; //Only in sanpshot
        public int time = 5; //Only in sanpshot
        public string textLog; //Only in Debug
        public int textSaveOption = 2; //0: Don't Save, 1: Capture Start, 2: Capture Over (Only in  Debug)
        public Text textLog_Text; //Only in Debug
        public bool textClear = true; //Only in Debug
        public bool activePause = true; //Onlt in Debug - When capture is start Save Option
        public string savePath;
        public bool isRecording = false; //Snapshot
        public bool isDebuging = false; //Debug

        [HideInInspector] public bool inPlayMode = false;
        private bool isCapturing = false;
        private float lastTimeScale;
        private int recordNumber = 0;

        private void Awake () {
            inPlayMode = true;
        }

        private void Update () {
            EventHandler ();
        }

        private void EventHandler () { //Key press detect method
            if (Input.GetKeyDown (captureKey)) StartCoroutine ("Rendering");
            if (textLog_Text != null) textLog_Text.text = textLog;
            if (textSaveOption != 1) activePause = true;
        }

        IEnumerator Rendering () {
            if (!isCapturing && !isRecording && !isDebuging) {
                isCapturing = true; //Capture start

                if (savePath != null && !savePath.Equals ("")) {

                    string fileExt = GetExtension ();
                    string date = GetDate ();

                    switch (mode) {
                        case Mode.Screenshot:
                            yield return new WaitForEndOfFrame (); //Capture must be taken when end of frame
                            string path = savePath + @"\" + date + fileExt;
                            Capture (Screen.width, Screen.height, path);
                            Debug.Log (path + " has been saved"); //Print Log
                            isCapturing = false; //End of capture
                            break;

                        case Mode.Snapshot:
                            string dirPath = savePath + @"\" + date;
                            Directory.CreateDirectory (dirPath);

                            Debug.Log ("Record Start");
                            isRecording = true;
                            int getRecordNumber = recordNumber; //Prevent overlap stop record
                            StartCoroutine (StopRecording (getRecordNumber, dirPath));

                            int seqNum = 1; //Image sequence number
                            float delay = (float)1 / frame; //Frame delay
                            while (isRecording) {
                                yield return new WaitForEndOfFrame ();
                                Capture (Screen.width, Screen.height, dirPath + @"\sequence" + seqNum + fileExt);
                                seqNum += 1;
                                yield return new WaitForSecondsRealtime (delay);
                            }  break; //End of capture sequence

                        case Mode.Debug:
                            if (activePause) { //When Pause is active
                                isDebuging = true;
                                lastTimeScale = Time.timeScale; //Save las time scale
                                Time.timeScale = 0; //Game pause
                            }

                            if (textSaveOption == 1) { //When capture is start
                                yield return new WaitForEndOfFrame ();
                                SaveImageWithText (true);
                                if (!activePause) isCapturing = false; //Capture over when pause is deactive
                            } break;
                    }

                } else Debug.LogError ("Can not found save path.");

            } else if (isCapturing && isRecording) {
                isRecording = false;
                isCapturing = false;
                Debug.Log ("Recording is canceled"); //Record cancel
                recordNumber += 1; //Prevent overlap stop record

            } else if (isCapturing && isDebuging) {
                if (textSaveOption == 2 || textSaveOption == 0) { //When capture is over
                    yield return new WaitForEndOfFrame ();
                    if (textSaveOption == 2) SaveImageWithText (true);
                    else SaveImageWithText (false);
                }

                isDebuging = false;
                isCapturing = false;
                Time.timeScale = lastTimeScale; //Game resume
            }
        }

        IEnumerator StopRecording (int localRecordNumber, string dirPath) {
            yield return new WaitForSecondsRealtime (time);
            if (localRecordNumber == recordNumber) { //Compare record number
                isRecording = false;
                isCapturing = false; //End of capture
                Debug.Log (dirPath + " Recording is complete");
                recordNumber += 1;
            }
        }

        public void Capture (int width, int height, string path) {
            byte[] imgBytes = null;

            Texture2D texture = new Texture2D (820, 644, TextureFormat.RGB24, false);
            texture.ReadPixels (new Rect (350, 187, width, height), 0, 0, false);
            texture.Apply (); //Make screen texture

            switch (extension) {
                case Extension.PNG: imgBytes = texture.EncodeToPNG (); break;
                case Extension.JPG: imgBytes = texture.EncodeToJPG (quality); break;
            } //Encoding file extension

            File.WriteAllBytes (path, imgBytes); //Write image file
        }

        public string GetTextName () { //For debug mode
            string line = textLog.Split ('\n')[0].Trim (); //line change detect

            int subStringLastIndex;
            if (line.Length > 40) subStringLastIndex = 40;
            else subStringLastIndex = line.Length; //Name words limit

            return line.Substring (0, subStringLastIndex);
        }

        public void SaveTextLog (string name, bool printLog) { //For debug mode
            if (textLog != null && !textLog.Equals ("")) { //Check contents blank

                string path = savePath + @"\" + name + ".txt"; //Set path
                File.WriteAllText (path, textLog); //Write text file

                if (textClear) textLog = ""; //Clear text area
                if (printLog) Debug.Log (path + " has been saved"); //Print log if called by pressing button
            } 
        }

        private void SaveImageWithText (bool saveText) { //For Save Text Option

            string fileExt = GetExtension ();
            bool isTextSaved = true; //For log

            string name = GetTextName ();
            if (name == null || name.Equals ("")) {
                name = GetDate ();
                isTextSaved = false;
            } //Text area blank check

            string imagePath = savePath + @"\" + name + fileExt; //Set path
            Capture (Screen.width, Screen.height, imagePath); //Capture
            if (saveText) SaveTextLog (name, false); //Save text file

            if (textLog_Text != null && textClear && textSaveOption == 0) textLog = "";
            //Clear text area if there's Text object, Text Clear is true, Save Option is 'Don't save' 

            if (isTextSaved && saveText) Debug.Log (savePath + @"\" + name + " " + fileExt + " and .txt has been saved"); //Print Log
            else Debug.Log (imagePath + " has been saved"); //When text is not saved
        }

        //Get file extension name
        public string GetExtension () {
            switch (extension) {
                case Extension.PNG: return ".png";
                case Extension.JPG: return ".jpg";
                default: return ".png";
            }
        }

        //Get date for name
        public string GetDate () {
            DateTime dt = DateTime.Now;
            return String.Format ("{0:yyyy/MM/dd} {0:HH_mm_ss}", dt, dt);
        }
    }
}
