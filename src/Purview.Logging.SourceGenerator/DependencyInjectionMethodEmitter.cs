﻿using System.Text;

namespace Logger.Gen;

sealed class DependencyInjectionMethodEmitter
{
	readonly string _interfaceName;
	readonly string _className;
	readonly string? _namespace;
	readonly bool _isPublic;

	public DependencyInjectionMethodEmitter(string interfaceName, string className, string? @namespace, bool isPublic)
	{
		_interfaceName = interfaceName;
		_className = className;
		_namespace = @namespace;
		_isPublic = isPublic;
	}

	public string Generate()
	{
		StringBuilder builder = new();

		// Start namespace.
		builder
			.AppendLine("namespace Microsoft.Extensions.DependencyInjection")
			.AppendLine("{");

		// Start class.
		builder
			.AppendLine("[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]")
			.Append("static ");

		if (_isPublic)
			builder.Append("public");
		else
			builder.Append("internal");

		builder
			.Append(" partial class ")
			.AppendLine(_className)
			.AppendLine("{");

		// Start method.
		builder
			.AppendLine("static public IServiceCollection AddLog<T>(this IServiceCollection services)")
			.AppendLine("where T : ")
			.Append(_namespace)
			.AppendLine(_interfaceName)
			.AppendLine("{");

		// Return block.
		builder
			.Append("return services.AddSingleton<")
			.Append(_namespace)
			.Append(_interfaceName)
			.Append(", ")
			.Append(_namespace)
			.Append(_className)
			.AppendLine(">();");

		builder
			// End method
			.AppendLine("}")
			// End class
			.AppendLine("}");

		// End namespace.
		builder
			.AppendLine("}")
			.AppendLine();

		return builder.ToString();
	}
}
