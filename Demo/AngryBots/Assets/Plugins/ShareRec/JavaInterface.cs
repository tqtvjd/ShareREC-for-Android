using System;
using UnityEngine;

namespace cn.sharerec {
#if UNITY_ANDROID

	public class JavaInterface {
		private AndroidJavaObject javaRecorder;

		public JavaInterface(string appkey, string gameObject) {
			try {
				AndroidJavaClass clz = null;
				clz = new AndroidJavaClass("cn.sharerec.recorder.UnityRecorder");
				javaRecorder = clz.CallStatic<AndroidJavaObject>("getInstance", appkey, gameObject);
			} catch(Exception e) {
				javaRecorder = null;
			}

			try {
				AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
				currentActivity.Call("setRecorder", javaRecorder);
			} catch(Exception e) {}
		}

		public void setOnRecorderStateListener(String go, String cb) {
			if (javaRecorder != null) {
				javaRecorder.Call("setOnRecorderStateListener", go, cb);
			}
		}

		public void setSampleRate(int sampleRate) {
			if (javaRecorder != null) {
				javaRecorder.Call("setSampleRate", sampleRate);
			}
		}

		public void setChannelCount(int channelCount) {
			if (javaRecorder != null) {
				javaRecorder.Call("setChannelCount", channelCount);
			}
		}

		public void setFrameRate(int frameRate) {
			if (javaRecorder != null) {
				javaRecorder.Call("setFrameRate", frameRate);
			}
		}

		public void onTheBeginningOfTheFrame() {
			if (javaRecorder != null) {
				javaRecorder.Call("onTheBeginningOfTheFrame");
			}
		}

		public void onTheEndOfTheFrame() {
			if (javaRecorder != null) {
				javaRecorder.Call("onTheEndOfTheFrame");
			}
		}

		public void start() {
			if (javaRecorder != null) {
				javaRecorder.Call("start");
			}
		}

		public void pause() {
			if (javaRecorder != null) {
				javaRecorder.Call("pause");
			}
		}

		public void resume() {
			if (javaRecorder != null) {
				javaRecorder.Call("resume");
			}
		}

		public void stop() {
			if (javaRecorder != null) {
				javaRecorder.Call("stop");
			}
		}

		public void setText(string text) {
			if (javaRecorder != null) {
				javaRecorder.Call("setText", text);
			}
		}

		public void addAttrData(String key, String value) {
			if (javaRecorder != null) {
				javaRecorder.Call("addAttrData", key, value);
			}
		}

		public bool isAvailable() {
			if (javaRecorder != null) {
				return javaRecorder.Call<bool>("isAvailable");
			}
			return false;
		}

		public void showShare() {
			if (javaRecorder != null) {
				javaRecorder.Call("showShare");
			}
		}

		public void showVideoCenter() {
			if (javaRecorder != null) {
				javaRecorder.Call("showVideoCenter");
			}
		}

		public void showProfile() {
			if (javaRecorder != null) {
				javaRecorder.Call("showProfile");
			}
		}

		public void clearCache() {
			if (javaRecorder != null) {
				javaRecorder.Call("clearCache");
			}
		}

		public void setBitRate(int bitRate) {
			if (javaRecorder != null) {
				javaRecorder.Call("setBitRate", bitRate);
			}
		}

		public void onPreRender() {
			if (javaRecorder != null) {
				javaRecorder.Call("onPreRender");
			}
		}
		
		public void onPostRender(int screenfbo) {
			if (javaRecorder != null) {
				javaRecorder.Call("onPostRender",screenfbo);
			}
		}

	}

#endif
}