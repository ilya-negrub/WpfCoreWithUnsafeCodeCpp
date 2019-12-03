#include "BitmapFilterRed.h"

Color BitmapFilterRed::UpdateColor(Color color)
{
	Color color_out;

	color_out.A = color.A;
	color_out.R = 0xFF ^ color.R;
	color_out.G = 0;
	color_out.B = 0;

	return color_out;
}
