﻿using HSF_HideAndSeek.Steganography.Logic;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace HSF_HideAndSeek.Forms {
	
	/// <summary>
	/// This class represents a form for the only purpose of displaying the eight red bit planes of a given carrier or stego image.
	/// </summary>
	public sealed partial class BitPlaneForm : Form {

		/// <summary>
		/// The original image the bit planes are to be extracted from
		/// </summary>
		private readonly Bitmap _image;

		/// <summary>
		/// Array storing the eight red bit planes of the specified image
		/// </summary>
		private Bitmap[] _bitPlanes = new Bitmap[8];

		/// <summary>
		/// Constructor: Generates a new form with a given name and
		/// displays the eight bit planes (red color channel) of the given image one after another.
		/// </summary>
		/// <param name="title">The form's title</param>
		/// <param name="image">The image whose bit planes are to be extracted from</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		/// <exception cref="Exception"></exception>
		public BitPlaneForm(string title, Bitmap image) {
			InitializeComponent();
			_image = new Bitmap(image);
			Text = title;
			
			// Prevent the GUI from blocking by generating the bit planes inside a new thread
			Thread thread = new Thread(DisplayBitPlanes);
			thread.Start();
		}

		/// <summary>
		/// Extracts the eight red bit planes and
		/// fills the picture boxes with them.
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		/// <exception cref="Exception"></exception>
		/// </summary>
		private void DisplayBitPlanes() {
			_bitPlanes[0] = BitPlaneExtractor.ExtractSingleBitPlane(_image, 0);
			bitPlanePictureBox0.Image = _bitPlanes[0];
			_bitPlanes[1] = BitPlaneExtractor.ExtractSingleBitPlane(_image, 1);
			bitPlanePictureBox1.Image = _bitPlanes[1];
			_bitPlanes[2] = BitPlaneExtractor.ExtractSingleBitPlane(_image, 2);
			bitPlanePictureBox2.Image = _bitPlanes[2];
			_bitPlanes[3] = BitPlaneExtractor.ExtractSingleBitPlane(_image, 3);
			bitPlanePictureBox3.Image = _bitPlanes[3];
			_bitPlanes[4] = BitPlaneExtractor.ExtractSingleBitPlane(_image, 4);
			bitPlanePictureBox4.Image = _bitPlanes[4];
			_bitPlanes[5] = BitPlaneExtractor.ExtractSingleBitPlane(_image, 5);
			bitPlanePictureBox5.Image = _bitPlanes[5];
			_bitPlanes[6] = BitPlaneExtractor.ExtractSingleBitPlane(_image, 6);
			bitPlanePictureBox6.Image = _bitPlanes[6];
			_bitPlanes[7] = BitPlaneExtractor.ExtractSingleBitPlane(_image, 7);
			bitPlanePictureBox7.Image = _bitPlanes[7];
		}

		/// <summary>
		/// Free memory at closing the form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BitPlaneForm_FormClosing(object sender, FormClosingEventArgs e) {
			_bitPlanes = null;
			try {
				bitPlanePictureBox0.Image.Dispose();
				bitPlanePictureBox1.Image.Dispose();
				bitPlanePictureBox2.Image.Dispose();
				bitPlanePictureBox3.Image.Dispose();
				bitPlanePictureBox4.Image.Dispose();
				bitPlanePictureBox5.Image.Dispose();
				bitPlanePictureBox6.Image.Dispose();
				bitPlanePictureBox7.Image.Dispose();
			} catch (Exception) {
				//this.Dispose();
			}
		}
	}
}
