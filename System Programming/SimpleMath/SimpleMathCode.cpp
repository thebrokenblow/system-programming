#include <Windows.h>

// Функция должна быть экспортируемой
extern "C" __declspec(dllexport) int Add(int a, int b)
{
	return a + b;
}