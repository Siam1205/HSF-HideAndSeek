﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace HFD_HideAndSeek.Cryptography {

	/// <summary>
	/// This class provides static methods for hashing input data with Sha256 and a predefined salt.
	/// </summary>
	internal class Hasher {

		/// <summary>
		/// Predefined salt for the hashing algorithms.
		/// It must be at least 8 bytes.
		/// </summary>
		private static readonly byte[] DefaultSalt = {
			0xEB, 0xAD, 0x90, 0x25, 0x2B, 0x70, 0x79, 0x48,
			0x62, 0x5E, 0x96, 0x85, 0x86, 0x8C, 0x20, 0x99,
			0xCA, 0xE6, 0xA0, 0xE8, 0x6B, 0xDB, 0x1A, 0x18,
			0x91, 0xFE, 0x34, 0x1C, 0xD3, 0xBE, 0x88, 0x8C,
			0x4B, 0xEB, 0xE6, 0x92, 0x5E, 0xD7, 0x06, 0xB1,
			0xF4, 0x04, 0x6C, 0x5A, 0x3C, 0x8F, 0x49, 0xEC,
			0x31, 0xAC, 0xC6, 0xA9, 0xF0, 0xD0, 0x4E, 0xBC,
			0x59, 0xE4, 0xB0, 0xDF, 0xB8, 0x6C, 0x4A, 0x71
		};

		#region Hash methods
		/// <summary>
		/// Hashes an arbitrary string and returns the hash value as byte array.
		/// </summary>
		/// <param name="input">The string which should be hashed</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ObjectDisposedException"></exception>
		/// <exception cref="System.Reflection.TargetInvocationException"></exception>
		/// <exception cref="EncoderFallbackException"></exception>
		/// <returns>The hashed string as byte array</returns>
		public static byte[] HashSha256(string input) {
			byte[] inputAsByteArray = Encoding.UTF8.GetBytes(input);
			byte[] inputWithSalt = Combine(DefaultSalt, inputAsByteArray);
			return SHA256.Create().ComputeHash(inputWithSalt);
		}

		/// <summary>
		/// Hashes an arbitrary byte array and returns the hash value as byte array.
		/// </summary>
		/// <param name="input">The byte array which should be hashed</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ObjectDisposedException"></exception>
		/// <exception cref="System.Reflection.TargetInvocationException"></exception>
		/// <returns>The hashed byte array</returns>
		public static byte[] HashSha256(byte[] input) {
			byte[] inputWithSalt = Combine(DefaultSalt, input);
			return SHA256.Create().ComputeHash(inputWithSalt);
		}
		#endregion

		#region Helper methods
		/// <summary>
		/// Combines two arrays and returns the new array
		/// </summary>
		/// <param name="first">The first array</param>
		/// <param name="second">The second array</param>
		/// <returns>The single combined array</returns>
		private static byte[] Combine(byte[] first, byte[] second) {
			byte[] newArray = new byte[first.Length + second.Length];
			Buffer.BlockCopy(first, 0, newArray, 0, first.Length);
			Buffer.BlockCopy(second, 0, newArray, first.Length, second.Length);
			return newArray;
		}
		#endregion
	}
}