#include "library.h"

JNIEXPORT int JNICALL Java_Program_add
  (JNIEnv* env, jobject thisObject, int a, int b) {
    return a + b;
}