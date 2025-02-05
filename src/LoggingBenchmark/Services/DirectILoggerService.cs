﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoggingBenchmark.Services;

sealed class DirectILoggerService : ServiceBase
{
	public void Execute()
	{
		using (Logger.BeginScope("TestStart => Started: {Started}", DateTimeOffset.UtcNow))
		{
			Logger.LogTrace("TestTrace: {StringParam}, {IntParam}", "A Trace Parameter", 1);
			Logger.LogDebug("TestDebug: {StringParam}, {IntParam}", "A Debug Parameter", 11);
			Logger.LogInformation("LogInformation: {StringParam}, {IntParam}", "A Information Parameter", 111);
			Logger.LogWarning("LogWarning: {StringParam}, {IntParam}", "A Warning Parameter", 1111);
			Logger.LogError("LogError: {StringParam}, {IntParam}", "A Error Parameter", 11111);
			Logger.LogCritical("LogCritical: {StringParam}, {IntParam}", "A Critical Parameter", 111111);
		}
	}

	ILogger<DirectILoggerService> Logger
		=> ServiceProvider.GetRequiredService<ILogger<DirectILoggerService>>();
}
