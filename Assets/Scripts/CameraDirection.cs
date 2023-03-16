using UnityEngine;
using System.Collections;

namespace PhatRobit
{
	public class CameraDirection : MonoBehaviour
	{
		protected CameraController _camera;


		//public virtual Facing Facing { get { return _facing; } }
		public virtual Vector2 Angle { get { return _camera.CurrentRotation; } }

        public virtual void Awake()
		{
			_camera = GetComponent<CameraController>();
		}

    }
}