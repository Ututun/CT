namespace LinearAlgebra
{
	public static class Algorithm
	{
		public static int FindInverseElementInZp(int element, int module)
		{
			int result = 1, power = module - 2, factor = element;

			while (power > 0)
			{
				if (power % 2 == 1)
					result = (result * factor) % module;
				factor *= factor;
				power /= 2;
			}

			return result < 0 ? result + module : result;
		}

		public static Polynomial GetQuotientInZp(Polynomial dividend, Polynomial divider, int module)
		{
			TakeByModule(ref dividend, module);
			TakeByModule(ref divider, module);

			if (dividend.Degree < divider.Degree)
				return new Polynomial(0);

			var result = new Polynomial(dividend.Degree - divider.Degree);
			while (dividend.Degree > 0 && dividend.Degree  >= divider.Degree)
			{
				int index = dividend.Degree - divider.Degree;
				var factor = new Polynomial(index);
				factor.LeadingCoefficient = 1;

				result[index] = (FindInverseElementInZp(divider.LeadingCoefficient, module) * dividend.LeadingCoefficient) % module;

				var subtrahend = divider * result[index] * factor;
				dividend = (dividend - subtrahend) % module;
			}

			result.DeleteLeadingZeros();

			return result;
		}

		public static Polynomial GetResidueInZp(Polynomial dividend, Polynomial divider, int module)
		{
			TakeByModule(ref dividend, module);
			TakeByModule(ref divider, module);

			if (dividend.Degree < divider.Degree)
				return new Polynomial(0);

			while (dividend.Degree > 0 && dividend.Degree >= divider.Degree)
			{
				var factor = new Polynomial(dividend.Degree - divider.Degree);
				factor.LeadingCoefficient = 1;

				int quotient = (FindInverseElementInZp(divider.LeadingCoefficient, module) * dividend.LeadingCoefficient) % module;

				var subtrahend = divider * quotient * factor;
				dividend = (dividend - subtrahend) % module;
			}

			return dividend;
		}

		public static Polynomial GCDInZp(Polynomial f, Polynomial g, int module)
		{
			TakeByModule(ref f, module);
			TakeByModule(ref g, module);

			while (f.Degree > 0 && g.Degree > 0)
				if (f.Degree > g.Degree)
					f = GetResidueInZp(f, g, module);
				else
					g = GetResidueInZp(g, f, module);

			return f.LeadingCoefficient == 0 ? g : f;
		}

		public static void TakeByModule(ref Polynomial polynomial, int module)
		{
			polynomial = polynomial % module;
			polynomial.DeleteLeadingZeros();
		}
	}
}
