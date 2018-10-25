using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.Mocking.Objects.Wrapper
{
	public interface ISubmissionWrapper
	{
		bool IsValid();
		void Submit();
	}
}
