#include "SharedAPI.h"

SHARED_API BitmapFilter* CreateBitmapFilter()
{
	return new BitmapFilter();
}

SHARED_API BitmapFilter* CreateBitmapFilterNegative()
{
	return new BitmapFilterNegative();
}

SHARED_API BitmapFilter* CreateBitmapFilterRed()
{
	return new BitmapFilterRed();
}

SHARED_API void SetPixels(BitmapFilter* bmpFilter, byte* pixels, size_t length)
{
	bmpFilter->SetPixels(pixels, length);
}

SHARED_API size_t GetLength(BitmapFilter* bmpFilter)
{
	return bmpFilter->GetLength();
}

SHARED_API byte* GetPixels(BitmapFilter* bmpFilter, size_t* length)
{
	return bmpFilter->GetPixels(length);
}

SHARED_API void Update(BitmapFilter* bmpFilter)
{
	bmpFilter->Update();
}

SHARED_API void Dispose(BitmapFilter* bmpFilter)
{
	bmpFilter->Dispose();
}
