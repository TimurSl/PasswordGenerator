using System;
using System.Security.Cryptography;

namespace MatrixRain
{
	public class CryptoRandom : RandomNumberGenerator
	{
		private static RandomNumberGenerator r;
		
		public CryptoRandom()
		{
			r = RandomNumberGenerator.Create();
		}
		
		public override void GetBytes(byte[] buffer)
		{
			r.GetBytes(buffer);
		}
		public double NextDouble()
		{
			byte[] b = new byte[4];
			r.GetBytes(b);
			return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
		}
		
		public int Next(int minPValue, int maxPValue)
		{
			return (int)Math.Round(NextDouble() * (maxPValue - minPValue - 1)) + minPValue;
		}
		public int Next()
		{
			return Next(0, Int32.MaxValue);
		}
		
		public int Next(int maxValue)
		{
			return Next(0, maxValue);
		}
		public override void GetNonZeroBytes(byte[] data)
		{
			throw new NotImplementedException();
		}
	}
}
