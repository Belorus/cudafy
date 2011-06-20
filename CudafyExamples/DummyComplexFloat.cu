struct DummyComplexFloat
{
	public: float Real;
	public: float Imag;

	// Methods
	__device__ DummyComplexFloat(float  r, float  i)
	{
		Real = r;
		Imag = i;
	}


	__device__ DummyComplexFloat  Add(DummyComplexFloat  c)
	{
		return DummyComplexFloat((Real + c.Real), (Imag + c.Imag));
	}
};