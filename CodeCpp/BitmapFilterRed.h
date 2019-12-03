#pragma once
#include "BitmapFilter.h"
class BitmapFilterRed :
	public BitmapFilter
{
protected:
	Color UpdateColor(Color color);
};

