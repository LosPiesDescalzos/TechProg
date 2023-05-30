#include <jni.h>

#ifndef add
#define add
#ifdef __cplusplus
extern "C" {
#endif

JNIEXPORT jint JNICALL Java_Program_add
  (JNIEnv *, jobject, jint, jint);

#ifdef __cplusplus
}
#endif
#endif