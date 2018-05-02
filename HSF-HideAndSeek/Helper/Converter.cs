﻿using HSF_HideAndSeek.Exceptions;
using System;
using System.Text;

namespace HSF_HideAndSeek.Helper {
	
	/// <summary>
	/// This class provides static methods for converting data into other representations or
	/// for converting a value from one data type into another one.
	/// </summary>
	internal class Converter {

		#region Conversions into binary string patterns

		/// <summary>
		/// Converts a text string to a binary string pattern.
		/// </summary>
		/// <param name="str"></param>
		/// <param name="zeroPadding"></param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="EncoderFallbackException"></exception>
		/// <exception cref="MessageNameTooBigException"></exception>
		/// <returns></returns>
		public static string StringToBinary(string str, int zeroPadding) {
			// TODO: Change this!

			UTF8Encoding encoding = new UTF8Encoding();
			byte[] buffer = encoding.GetBytes(str);

			if (buffer.Length > 64) {
				throw new MessageNameTooBigException();
			}

			if (buffer.Length < 64) {
				Array.Resize(ref buffer, zeroPadding);
			}

			StringBuilder sb = new StringBuilder();
			foreach (byte element in buffer) {
				sb.Append(Convert.ToString(element, 2).PadLeft(8, '0'));
			}
			return sb.ToString();
		}

		/// <summary>
		/// Converts a long variable to its binary string representation and fills it with a
		/// specified amount of zeros to the left.
		/// </summary>
		/// <param name="decimalNumber">The decimal number which is to be converted into a binary number</param>
		/// <param name="zeroPadding">The amount of zeros that the binary number should be padded with</param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		/// <returns>The binary representation of the given decimal number</returns>
		public static string DecimalToBinary(long decimalNumber, int zeroPadding) {
			if (zeroPadding != 0) {
				return Convert.ToString(decimalNumber, 2).PadLeft(zeroPadding, '0');
			}
			return Convert.ToString(decimalNumber, 2);
		}

		/// <summary>
		/// Converts a uint variable to its binary string representation and fills it with a
		/// specified amount of zeros to the left.
		/// </summary>
		/// <param name="decimalNumber">The decimal number which is to be converted into a binary number</param>
		/// <param name="zeroPadding">The amount of zeros that the binary number should be padded with</param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		/// <returns>The binary representation of the given decimal number</returns>
		public static string DecimalToBinary(uint decimalNumber, int zeroPadding) {
			if (zeroPadding != 0) {
				return Convert.ToString(decimalNumber, 2).PadLeft(zeroPadding, '0');
			}
			return Convert.ToString(decimalNumber, 2);
		}

		/// <summary>
		/// Converts a byte variable to its binary string representation and fills it with a
		/// specified amount of zeros to the left.
		/// </summary>
		/// <param name="decimalNumber">The decimal number which is to be converted into a binary number</param>
		/// <param name="zeroPadding">The amount of zeros that the binary number should be padded with</param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		/// <returns>The binary representation of the given decimal number</returns>
		public static string DecimalToBinary(byte decimalNumber, int zeroPadding) {
			if (zeroPadding != 0) {
				return Convert.ToString(decimalNumber, 2).PadLeft(zeroPadding, '0');
			}
			return Convert.ToString(decimalNumber, 2);
		}

		/// <summary>
		/// Converts a byte array to its binary string representation.
		/// For this purpose no padding is necessary since a byte variable always uses 8 digits.
		/// </summary>
		/// <param name="array">The byte array which is to be converted into a binary string</param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		/// <returns>The binary representation of the given byte array</returns>
		public static string ByteArrayToBinary(byte[] array) {
			StringBuilder sb = new StringBuilder();
			foreach (byte by in array) {
				sb.Append(DecimalToBinary(by, 8));
			}
			return sb.ToString();
		}
		#endregion

		#region Conversions from binary representations into variables or objects

		/// <summary>
		/// Converts a binary string pattern into its respective UTF8 text representation.
		/// </summary>
		/// <param name="str"></param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="FormatException"></exception>
		/// <exception cref="OverflowException"></exception>
		/// <exception cref="DecoderFallbackException"></exception>
		/// <returns></returns>
		public static string BinaryToString(string str) {
			//byte[] temp = Extensions.ConvertBitstringToByteArray(str);
			byte[] temp = str.ConvertBitstringToByteArray();

			string val = Encoding.UTF8.GetString(temp);
			return val;
		}

		/// <summary>
		/// Converts a binary string pattern to a byte variable
		/// </summary>
		/// <param name="binary"></param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		/// <exception cref="FormatException"></exception>
		/// <exception cref="OverflowException"></exception>
		/// <returns></returns>
		public static byte BinaryToByte(string binary) {
			byte by = Convert.ToByte(binary, 2);
			return by;
		}

		/// <summary>
		/// Calls an extension method to convert a binary string pattern to a byte array
		/// </summary>
		/// <param name="binary"></param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		/// <exception cref="FormatException"></exception>
		/// <exception cref="OverflowException"></exception>
		/// <returns></returns>
		public static byte[] BinaryToByteArray(string binary) {
			return binary.ConvertBitstringToByteArray();
		}

		/// <summary>
		/// Converts a binary string pattern to a uint variable
		/// </summary>
		/// <param name="binary"></param>
		/// /// <exception cref="ArgumentException"></exception>
		/// /// <exception cref="ArgumentOutOfRangeException"></exception>
		/// /// <exception cref="FormatException"></exception>
		/// /// <exception cref="OverflowException"></exception>
		/// <returns></returns>
		public static uint BinaryToUint(string binary) {
			uint unsignedInt = Convert.ToUInt32(binary, 2);
			return unsignedInt;
		}
		#endregion

		/// <summary>
		/// Converts a uint variable storing a bit value
		/// into a double variable storing the value in kB
		/// </summary>
		/// <param name="bits"></param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		/// <returns></returns>
		public static double BitsToKiloBytes(uint bits) {
			// ReSharper disable once PossibleLossOfFraction
			float bytes = bits / 8;
			float kiloBytes = bytes / 1024;
			return Math.Round(kiloBytes, 5);
		}

		/// <summary>
		/// Converts a double value of bytes into its human readable string representation
		/// </summary>
		/// <param name="len"></param>
		/// <returns></returns>
		public static string BytesToHumanReadableString(double len) {
			string[] sizes = { "B", "KB", "MB", "GB", "TB" };
			int order = 0;
			while (len >= 1024 && order < sizes.Length - 1) {
				order++;
				len = len / 1024;
			}
			return String.Format("{0:0.##} {1}", len, sizes[order]);
		}
	}
}
