﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HSA.DataAccess
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="HSARuns")]
	public partial class HSARunsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertzzArenaRun(zzArenaRun instance);
    partial void UpdatezzArenaRun(zzArenaRun instance);
    partial void DeletezzArenaRun(zzArenaRun instance);
    #endregion
		
		public HSARunsDataContext() : 
				base(global::HSA.Properties.Settings.Default.HSARunsConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public HSARunsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HSARunsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HSARunsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HSARunsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<zzArenaRun> zzArenaRuns
		{
			get
			{
				return this.GetTable<zzArenaRun>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.zzArenaRuns")]
	public partial class zzArenaRun : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _RunID;
		
		private System.Nullable<int> _Wins;
		
		private System.Nullable<int> _Losses;
		
		private string _Hero;
		
		private System.Nullable<System.DateTime> _RunDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRunIDChanging(int value);
    partial void OnRunIDChanged();
    partial void OnWinsChanging(System.Nullable<int> value);
    partial void OnWinsChanged();
    partial void OnLossesChanging(System.Nullable<int> value);
    partial void OnLossesChanged();
    partial void OnHeroChanging(string value);
    partial void OnHeroChanged();
    partial void OnRunDateChanging(System.Nullable<System.DateTime> value);
    partial void OnRunDateChanged();
    #endregion
		
		public zzArenaRun()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RunID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int RunID
		{
			get
			{
				return this._RunID;
			}
			set
			{
				if ((this._RunID != value))
				{
					this.OnRunIDChanging(value);
					this.SendPropertyChanging();
					this._RunID = value;
					this.SendPropertyChanged("RunID");
					this.OnRunIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Wins", DbType="Int")]
		public System.Nullable<int> Wins
		{
			get
			{
				return this._Wins;
			}
			set
			{
				if ((this._Wins != value))
				{
					this.OnWinsChanging(value);
					this.SendPropertyChanging();
					this._Wins = value;
					this.SendPropertyChanged("Wins");
					this.OnWinsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Losses", DbType="Int")]
		public System.Nullable<int> Losses
		{
			get
			{
				return this._Losses;
			}
			set
			{
				if ((this._Losses != value))
				{
					this.OnLossesChanging(value);
					this.SendPropertyChanging();
					this._Losses = value;
					this.SendPropertyChanged("Losses");
					this.OnLossesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hero", DbType="VarChar(255)")]
		public string Hero
		{
			get
			{
				return this._Hero;
			}
			set
			{
				if ((this._Hero != value))
				{
					this.OnHeroChanging(value);
					this.SendPropertyChanging();
					this._Hero = value;
					this.SendPropertyChanged("Hero");
					this.OnHeroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RunDate", DbType="Date")]
		public System.Nullable<System.DateTime> RunDate
		{
			get
			{
				return this._RunDate;
			}
			set
			{
				if ((this._RunDate != value))
				{
					this.OnRunDateChanging(value);
					this.SendPropertyChanging();
					this._RunDate = value;
					this.SendPropertyChanged("RunDate");
					this.OnRunDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
