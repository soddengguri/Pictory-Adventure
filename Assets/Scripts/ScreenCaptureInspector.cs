using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace WorkPlus {

    [CustomEditor (typeof (ScreenCapture))]
    public class ScreenCaptureInspector : Editor {

        /// <summary>
        /// Custom Inspector for ScreenCapture script.
        /// </summary>

        /* Text Save Option Elements */
        string[] textSaveOptionStrings = { "Don't Save", "When Capture Is Start", "When Capture Is Over" };
        int[] textSaveOptionInts = { 0, 1, 2 };

        public override void OnInspectorGUI () {

            ScreenCapture sc = target as ScreenCapture; //Get target as ScreenCapture

            //Show Mode (enum)
            sc.mode = (ScreenCapture.Mode)EditorGUILayout.EnumPopup
                (new GUIContent ("Shot Mode","Set way to take a picture"), sc.mode);

            //Mode Explanation
            if (sc.mode.Equals (ScreenCapture.Mode.Snapshot))
                GUILayout.Box ("When it's in recording, You can stop it by pressing capture key again (JPG Extension Recommended)");
            else if (sc.mode.Equals (ScreenCapture.Mode.Debug))
                GUILayout.Box ("When you use capture, Time Scale is set to 0. And prees it again, go back to last Time Scale ");
            if (!sc.mode.Equals (ScreenCapture.Mode.Screenshot)) GUILayout.Space (8f);

            //Show Capture Key (KeyCode)
            sc.captureKey = (KeyCode)EditorGUILayout.EnumPopup
                (new GUIContent ("Capture Key", "Screen capture key (In Play Mode)"), sc.captureKey);
            if (sc.captureKey == KeyCode.None)
                GUILayout.Box ("You need to setting capture key to take a picture."); //Key undefined warning

            //Show Extension (enum)
            sc.extension = (ScreenCapture.Extension)EditorGUILayout.EnumPopup
                (new GUIContent ("Extension", "Extenstion of save file (JPG is faster then PNG but it's more bigger)"), sc.extension);

            //Show Quality (int) when Extension is JPG
            if (sc.extension.Equals (ScreenCapture.Extension.JPG)) {
                sc.quality = EditorGUILayout.IntSlider
                    (new GUIContent ("Quality", "Image Quality of JPG (Large scale by high quality) [Default = 75]"), sc.quality, 1, 100);
            }

            //Show Frame and Time (int) when Mode is Snapshot
            if (sc.mode.Equals (ScreenCapture.Mode.Snapshot)) {
                sc.frame = EditorGUILayout.IntSlider
                    (new GUIContent ("Frame", "Frame per second (Default = 3)"), sc.frame, 1, 6);
                sc.time = EditorGUILayout.IntSlider
                    (new GUIContent ("Record Time", "Record time (0 is infinite)"), sc.time, 1, 60);
                if (sc.isRecording) GUILayout.Box ("Now Recording"); //Recording Notice
            
            //Show Debug Elements when Mode is Debug
            } else if (sc.mode.Equals (ScreenCapture.Mode.Debug)) {
                GUILayout.Space (8f);

                GUILayout.BeginHorizontal (); //BeginHorizontal
                GUILayout.Label (new GUIContent ("Text Log", "If text is blank, it will not saved")); //Label
                if (GUILayout.Button ("Save Text", GUILayout.Height (16f))) {
                    if (sc.textLog != null && !sc.textLog.Equals ("")) {
                        sc.SaveTextLog (sc.GetTextName (), true);
                    } else Debug.LogError ("It's not contain any text.");
                } //Text Save Button
                GUILayout.EndHorizontal (); //EndHorizontal

                sc.textLog = EditorGUILayout.TextArea (sc.textLog, GUILayout.Height (48f)); //Text Area
                GUILayout.Space (4f);
                sc.textSaveOption = EditorGUILayout.IntPopup //Text Save Option Int Popup
                    ("Text Save Option", sc.textSaveOption, textSaveOptionStrings, textSaveOptionInts);
                sc.textLog_Text = (Text)EditorGUILayout.ObjectField //Text obejct
                    (new GUIContent ("Text UI", "Select Text UI in canvas, The text contents will follow Text Log"), 
                    sc.textLog_Text, typeof (Text), true);
                sc.textClear = EditorGUILayout.Toggle //Text Clear boolean
                    (new GUIContent ("Clear Text", "Clear text area when text is saved or Text object exist and it's Don't Save Option"),
                    sc.textClear);
                if (sc.textSaveOption == 1) sc.activePause = EditorGUILayout.Toggle //Active Pause boolean
                        (new GUIContent ("Active Pause", "If it unchecked, Time Scale is not be changed when use capture"), sc.activePause);
                if (sc.isDebuging) GUILayout.Box ("Now Pausing"); //Pausing Notice
                GUILayout.Space (8f);
            }

            //Show Save Path (string)
            sc.savePath = EditorGUILayout.TextField
                (new GUIContent ("Save Path", "The save path of picture"), sc.savePath);
            if (sc.savePath == null || sc.savePath.Equals (""))
                GUILayout.Box ("You have to setting save path to save capture."); //Path undefined warning
        }
    }
}
