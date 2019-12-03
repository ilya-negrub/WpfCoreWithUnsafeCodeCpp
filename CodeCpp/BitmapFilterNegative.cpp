#include "BitmapFilterNegative.h"


Color BitmapFilterNegative::UpdateColor(Color color)
{
	Color color_out;

	color_out.A = color.A;
	color_out.R = 0xFF ^ color.R;
	color_out.G = 0xFF ^ color.G;
	color_out.B = 0xFF ^ color.B;

	return color_out;
}
