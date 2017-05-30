﻿using System;
using Gtk;

namespace Sudoku
{
public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnGenerateSudClicked (object sender, EventArgs e)
	{
			Plansza plansza_sud = new Plansza ();
			plansza_sud.ShowAll();

	}
}
}