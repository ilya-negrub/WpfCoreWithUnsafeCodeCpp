#pragma once
#include "BitmapFilter.h"
class BitmapFilterNegative :
	public BitmapFilter
{
protected:
	Color UpdateColor(Color color);
};

