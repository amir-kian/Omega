using Omega.Domain.Enums;

namespace Omega.Domain.Entities
{
	public class Request
	{
		public int Id { get; private set; }
		public string Title { get; private set; }
		public RequestType RequestType { get; private set; }

		private double _fund;

		public double Fund
		{
			get => _fund;

			set
			{
				if (value < GetMinValue(RequestType) || value > GetMaxValue(RequestType))
				{
					throw new ArgumentOutOfRangeException(nameof(Fund), $"The Fund must be between {GetMinValue(RequestType)} and {GetMaxValue(RequestType)}.");
				}

				_fund = value;
			}
		}

		private Request() { }

		public Request(string title, RequestType requestType, double fund)
		{
			Title = title;
			RequestType = requestType;
			Fund = fund;

		}

		public static double GetMinValue(RequestType requestType)
		{
			switch (requestType)
			{
				case RequestType.Surgery:
					return 5000;

				case RequestType.Dental:
					return 4000;

				case RequestType.Hospitalization:
					return 2000;

				default:
					throw new ArgumentOutOfRangeException(nameof(requestType), "Invalid request type");
			}
		}

		public static double GetMaxValue(RequestType requestType)
		{
			switch (requestType)
			{
				case RequestType.Surgery:
					return 500000000;

				case RequestType.Dental:
					return 400000000;

				case RequestType.Hospitalization:
					return 200000000;

				default:
					throw new ArgumentOutOfRangeException(nameof(requestType), "Invalid request type");
			}
		}

		public static double GetInsuranceRate(RequestType requestType)
		{
			switch (requestType)
			{
				case RequestType.Surgery:
					return 0.0052;

				case RequestType.Dental:
					return 0.0042;

				case RequestType.Hospitalization:
					return 0.005;

				default:
					throw new ArgumentOutOfRangeException(nameof(requestType), "Invalid request type");
			}
		}
		public double GetInsurancePremium(RequestType requestType, double Fund)
		{
			double insuranceRate = GetInsuranceRate(requestType);
			return insuranceRate * Fund;
		}
	}
}