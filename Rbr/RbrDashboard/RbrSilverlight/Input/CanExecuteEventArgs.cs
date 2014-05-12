﻿// <copyright file="CanExecuteEventArgs.cs" company="no company">
// Distributed under Microsoft Public License (Ms-PL)
// </copyright>
using System;

namespace RbrSiverlight.Input {
	public class CanExecuteEventArgs : EventArgs {
		/// <summary>
		/// Initializes a new instance of the <see cref="CanExecuteEventArgs"/> class.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="parameter">The parameter.</param>
		internal CanExecuteEventArgs(Command command, object parameter) {
			Command = command;
			Parameter = parameter;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the System.Windows.Input.RoutedCommand
		/// associated with this event can be executed on the command target.
		/// </summary>
		/// <value>
		/// true if the event can be executed on the command target; otherwise, false.
		/// The default value is false.
		/// </value>
		public bool CanExecute { get; set; }

		/// <summary>
		/// Gets the command associated with this event.
		/// </summary>
		/// <value>The command. Unless the command is a custom command, this is generally a System.Windows.Input.RoutedCommand. There is no default value.</value>
		public Command Command { get; private set; }

		/// <summary>
		/// Gets the command specific data.
		/// </summary>
		/// <value>The command data. The default value is null.</value>
		public object Parameter { get; private set; }
	}
}