using System;

/// <summary>
/// Auto-generated code
/// </summary>
namespace CodeGeneration.DataTransferObjects
{
	public partial class Sum : BaseDataTransferObject, ISum, IDataTransferObject
	{
		private double _x;
		/// <summary>
		/// X
		/// </summary>
		public double X
		{
			get => _x;
			set => SetValue(nameof(X), ref _x, value);
		}

		private double _y;
		/// <summary>
		/// Y
		/// </summary>
		public double Y
		{
			get => _y;
			set => SetValue(nameof(Y), ref _y, value);
		}

		private double _result;
		/// <summary>
		/// Result
		/// </summary>
		public double Result
		{
			get => _result;
			set => SetValue(nameof(Result), ref _result, value);
		}

		public override BusinessObjects.IBusinessObject ToBusinessObject()
		{
			var result = new BusinessObjects.Sum();
			result.TrackingValueChange = false;
			ToBusinessObject(result);
			result.TrackingValueChange = true;
			return result;
		}
		
		public override BusinessObjects.IBusinessObject ToBusinessObject(BusinessObjects.IBusinessObject businessObject)
		{
			var result = (BusinessObjects.Sum)base.ToBusinessObject(businessObject);
			result.X = X;
			result.Y = Y;
			result.Result = Result;
			return result;
		}
	}
}