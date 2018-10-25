using System;
using System.ServiceModel;

namespace Katas.Mocking.Service
{
	[ServiceContract(ConfigurationName = "IKataService")]
	public interface IKataService
	{
		[OperationContract]
		byte[] ProcessSubmission(byte[] entitiesDto);
		
		[OperationContract]
		string GetSubmissionUrl(byte[] entitiesDto);
	}
}