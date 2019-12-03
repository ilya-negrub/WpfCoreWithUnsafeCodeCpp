#pragma once
#include "stdafx.h"


struct Color
{
	byte R;
	byte G;
	byte B;
	byte A;
};

class BitmapFilter
{
private:
	void PixelUpdate(size_t num);
protected:
	size_t _length = 0;
	byte* _pixels = nullptr;
	virtual Color UpdateColor(Color color) { return color; }
public:
	void SetPixels(byte* pixels, size_t length);
	size_t GetLength();
	byte* GetPixels(size_t* length);
	void Update();
	
	void Dispose();
};

