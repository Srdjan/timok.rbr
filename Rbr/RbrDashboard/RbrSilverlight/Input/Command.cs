﻿// <copyright file="Command.cs" company="no company">
// Distributed under Microsoft Public License (Ms-PL)
// </copyright>
using System;
using System.Collections.Generic;

namespace RbrSiverlight.Input {
	/// <summary>
	/// Command pattern implementation
	/// </summary>
	public class Command {
		#region Constructors

		/// <summary>
		/// Static constructor. Initialize static properties
		/// </summary>
		static Command() {
			CommandCache = new Dictionary<string, Command>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Command"/> class.
		/// </summary>
		/// <param name="commandName">The command name used for retreiving command in Xaml.</param>
		public Command(string commandName) {
			if (CommandCache.ContainsKey(commandName)) {
				throw new ArgumentException("A command with the same name '{0}' is already registered.", commandName);
			}

			Name = commandName;
			CommandCache.Add(commandName, this);
		}

		#endregion Constructors

		#region Events

		/// <summary>
		/// Check if the specified command can be executed.
		/// </summary>
		public event EventHandler<CanExecuteEventArgs> CanExecute;

		/// <summary>
		/// Occurs when the command is executed.
		/// </summary>
		public event EventHandler<ExecutedEventArgs> Executed;

		#endregion Events

		#region Public Properties

		/// <summary>
		/// Gets the command cache.
		/// </summary>
		/// <value>The command cache.</value>
		public static Dictionary<string, Command> CommandCache { get; private set; }

		/// <summary>
		/// Gets the name of the command.
		/// </summary>
		/// <value>the name of the command.</value>
		public string Name { get; private set; }

		#endregion Public Properties

		#region Public Methods

		/// <summary>
		/// Executes the command
		/// </summary>
		public virtual void Execute() {
			Execute(null);
		}

		/// <summary>
		/// Executes the command
		/// </summary>
		/// <param name="parameter">The parameter.</param>
		public virtual void Execute(object parameter) {
			if (RaiseCanExecute(parameter)) {
				if (Executed != null) {
					var e = new ExecutedEventArgs(this, parameter);
					Executed(this, e);
				}
			}
		}

		/// <summary>
		/// Executes the command
		/// </summary>
		/// <param name="parameter">The parameter.</param>
		/// <param name="source">The event source.</param>
		public virtual void Execute(object parameter, object source) {
			if (RaiseCanExecute(parameter)) {
				if (Executed != null) {
					var e = new ExecutedEventArgs(this, parameter, source);
					Executed(this, e);
				}
			}
		}

		/// <summary>
		/// Raises the can execute event.
		/// </summary>
		/// <param name="parameter">The parameter.</param>
		/// <returns>returns <c>true</c> if the command can be executed, otherwise <c>false</c>.</returns>
		public virtual bool RaiseCanExecute(object parameter) {
			if (CanExecute != null) {
				var e = new CanExecuteEventArgs(this, parameter);
				CanExecute(this, e);
				return e.CanExecute;
			}

			return true;
		}

		#endregion Public Methods
	}
}