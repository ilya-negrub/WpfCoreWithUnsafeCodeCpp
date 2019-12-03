#pragma once
#include "BitmapFilter.h"
#include "BitmapFilterNegative.h"
#include "BitmapFilterRed.h"
#include "stdafx.h"

#define SHARED_API __declspec(dllexport)

extern "C" {
	SHARED_API BitmapFilter* CreateBitmapFilter();
	SHARED_API BitmapFilter* CreateBitmapFilterNegative();
	SHARED_API BitmapFilter* CreateBitmapFilterRed();

	SHARED_API void SetPixels(BitmapFilter* bmpFilter, byte* pixels, size_t length);
	SHARED_API size_t GetLength(BitmapFilter* bmpFilter);
	SHARED_API byte* GetPixels(BitmapFilter* bmpFilter, size_t* length);
	SHARED_API void Update(BitmapFilter* bmpFilter);
	SHARED_API void Dispose(BitmapFilter* bmpFilter);
}