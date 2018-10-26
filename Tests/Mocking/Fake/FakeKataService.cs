using Katas.Mocking.Service;

namespace Tests.Mocking.Fake
{
	public class FakeKataService : IKataService
	{
		public string GetSubmissionUrl(byte[] entitiesDto)
		{
			return "http://localhost.grangeagent.com/Katas/SubmissionResults.aspx";
		}

		public byte[] ProcessSubmission(byte[] entitiesDto)
		{
			return new byte[0];
		}
	}
}
