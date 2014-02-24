using System;
using System.Collections;

namespace LinearAlgebra
{
	public class Polynomial : ICollection
	{
		public int Degree { get; private set; }
		public int Count { get { return Coefficients.Count; } }
		public RowVector Coefficients { get; private set; }

		public Polynomial()
		{
			Degree = -1;
			Coefficients = new RowVector(0);
		}

		public Polynomial(int degree)
		{
			Degree = degree;
			Coefficients = new RowVector(degree + 1);
		}

		public Polynomial(RowVector coefficients)
		{
			Degree = coefficients.Count + 1;
			Coefficients = coefficients;
		}

		private static void Swap(Polynomial leftHandSide, Polynomial rightHandSide)
		{
			var temporal = leftHandSide;
			leftHandSide = rightHandSide;
			rightHandSide = temporal;
		}

		public void DeleteLeadingZeros()
		{
			while (Degree > 0 && Coefficients[Degree] == 0)
				--Degree;

			Coefficients = Coefficients.GetPart(0, Degree + 1);
		}

		public static Polynomial operator +(Polynomial leftHandSide, Polynomial rightHandSide)
		{
			if (leftHandSide.Count < rightHandSide.Count)
				Swap(leftHandSide, rightHandSide);

			var result = new Polynomial(leftHandSide.Degree);

			for (int i = 0; i < rightHandSide.Count; ++i)
				result[i] = leftHandSide[i] + rightHandSide[i];
			for (int i = rightHandSide.Count; i < leftHandSide.Count; ++i)
				result[i] = leftHandSide[i];

			result.DeleteLeadingZeros();

			return result;
		}

		public static Polynomial operator -(Polynomial leftHandSide, Polynomial rightHandSide)
		{
			int maxCount = Math.Max(leftHandSide.Count, rightHandSide.Count);
			var result = new Polynomial(maxCount);

			for (int i = 0; i < maxCount; ++i)
				if (i < leftHandSide.Count && i < rightHandSide.Count)
					result[i] = leftHandSide[i] - rightHandSide[i];
				else if (i < leftHandSide.Count)
					result[i] = leftHandSide[i];
				else
					result[i] = -rightHandSide[i];

			result.DeleteLeadingZeros();

			return result;
		}

		public static Polynomial operator *(Polynomial leftHandSide, Polynomial rightHandSide)
		{
			var result = new Polynomial(leftHandSide.Degree + rightHandSide.Degree);

			for (int i = 0; i < leftHandSide.Count; ++i)
				for (int j = 0; j < rightHandSide.Count; ++j)
					result[i + j] += leftHandSide[i] * rightHandSide[j];

			return result;
		}

		public static Polynomial operator *(Polynomial polynomial, int number)
		{
			var result = new Polynomial(polynomial.Degree);

			for (int i = 0; i < polynomial.Count; ++i)
				result[i] = polynomial[i] * number;

			return result;
		}

		public static bool operator ==(Polynomial leftHandSide, Polynomial rightHandSide)
		{
			if (leftHandSide.Count != rightHandSide.Count)
				return false;

			for (int i = 0; i < leftHandSide.Count; ++i)
				if (leftHandSide[i] != rightHandSide[i])
					return false;

			return true;
		}

		public static bool operator !=(Polynomial leftHandSide, Polynomial rightHandSide)
		{
			return !(leftHandSide == rightHandSide);
		}

		public static Polynomial operator %(Polynomial polynomial, int module)
		{
			var result = new Polynomial(polynomial.Degree);

			for (int i = 0; i < polynomial.Count; ++i)
			{
				result[i] = polynomial[i] % module;
				if (result[i] < 0)
					result[i] += module;
			}

			result.DeleteLeadingZeros();

			return result;
		}

		public void Add(int item)
		{
			++Degree;
			Coefficients.Add(item);
		}

		public int LeadingCoefficient 
		{
			get { return Coefficients[Degree]; }
			set { Coefficients[Degree] = value; } 
		}

		public int this[int index]
		{
			get { return Coefficients[index]; }
			set { Coefficients[index] = value; }
		}

		#region ICollection

		public void CopyTo(System.Array array, int index)
		{
			for (int i = 0; i < Count; ++i)
				array.SetValue(Coefficients[i], index + i);
		}

		public bool IsSynchronized
		{
			get { throw new System.NotImplementedException(); }
		}

		public object SyncRoot
		{
			get { throw new System.NotImplementedException(); }
		}

		public IEnumerator GetEnumerator()
		{
			return Coefficients.GetEnumerator();
		}

		#endregion
	}
}
