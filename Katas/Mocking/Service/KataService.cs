﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8762
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// "C:\Program Files\Microsoft SDKs\Windows\v6.0A\Bin\svcutil.exe" http://localhost/KataService/KataService.svc

using Katas.Mocking.Service;

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IKataServiceChannel : IKataService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class KataServiceClient : System.ServiceModel.ClientBase<IKataService>, IKataService
{

	public KataServiceClient()
	{
	}

	public KataServiceClient(string endpointConfigurationName) :
			base(endpointConfigurationName)
	{
	}

	public KataServiceClient(string endpointConfigurationName, string remoteAddress) :
			base(endpointConfigurationName, remoteAddress)
	{
	}

	public KataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
			base(endpointConfigurationName, remoteAddress)
	{
	}

	public KataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
			base(binding, remoteAddress)
	{
	}

	public byte[] ProcessSubmission(byte[] entitiesDto)
	{
		return base.Channel.ProcessSubmission(entitiesDto);
	}

	public string GetSubmissionUrl(byte[] entitiesDto)
	{
		return base.Channel.GetSubmissionUrl(entitiesDto);
	}
}
