using System;

/// <summary>
/// Auto-generated code
/// </summary>
namespace CodeGeneration.BusinessObjects
{
	public partial class Sum : BaseBusinessObject, ISum
	{
		public Sum() : this (nameof(Sum), null)
		{

		}
		public Sum(string name, string caption) : base (name, caption)
		{

		}

		/// <summary>
		/// X
		/// </summary>
		public double X
		{
			get => XField.Value;
			set => XField.Value = value;
		}
		protected Field<double> XField { get; set; }

		/// <summary>
		/// Y
		/// </summary>
		public double Y
		{
			get => YField.Value;
			set => YField.Value = value;
		}
		protected Field<double> YField { get; set; }

		/// <summary>
		/// Result
		/// </summary>
		public double Result
		{
			get => ResultField.Value;
			set => ResultField.Value = value;
		}
		protected Field<double> ResultField { get; set; }
		
		protected override void CreateGeneratedFields()
		{
			base.CreateGeneratedFields();
		
			XField = AddField(new Field<double>(this));
			XField.Name = "X";
			XField.Caption = "X";

			YField = AddField(new Field<double>(this));
			YField.Name = "Y";
			YField.Caption = "Y";

			ResultField = AddField(new Field<double>(this));
			ResultField.Name = "Result";
			ResultField.Caption = "Result";
		}
		
		public override DataTransferObjects.IDataTransferObject ToDataTransferObject()
		{
			var result = new DataTransferObjects.Sum();
			result.TrackingValueChange = false;
			ToDataTransferObject(result);
			result.TrackingValueChange = true;
			return result;
		}
		
		public override DataTransferObjects.IDataTransferObject ToDataTransferObject(DataTransferObjects.IDataTransferObject dataTransferObject)
		{
			var result = (DataTransferObjects.Sum)base.ToDataTransferObject(dataTransferObject);
			result.X = X;
			result.Y = Y;
			result.Result = Result;
			return result;
		}
	}
}