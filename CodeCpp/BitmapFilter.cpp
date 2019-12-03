#include "BitmapFilter.h"

void BitmapFilter::SetPixels(byte* pixels, size_t length)
{
	Dispose();
	_length = length;
	_pixels = new byte[length];

	memcpy(_pixels, pixels, _length);
}

size_t BitmapFilter::GetLength()
{
	return _length;
}

byte* BitmapFilter::GetPixels(size_t* length)
{
	*length = _length;
	return _pixels;
}

void BitmapFilter::Update()
{
	size_t i = 0;
	while (i < _length)
	{
		PixelUpdate(i);
		i += 4;
	}
}

void BitmapFilter::PixelUpdate(size_t num)
{
	Color color = Color();

	color.R = _pixels[num + 2];
	color.G = _pixels[num + 1];
	color.B = _pixels[num + 0];
	color.A = _pixels[num + 3];

	Color color_out = UpdateColor(color);

	_pixels[num + 2] = color_out.R;
	_pixels[num + 1] = color_out.G;
	_pixels[num + 0] = color_out.B;
	_pixels[num + 3] = color_out.A;
}

void BitmapFilter::Dispose()
{
	if (_length == 0 || _pixels == nullptr)
		return;
	_length = 0;
	delete[] _pixels;
}

