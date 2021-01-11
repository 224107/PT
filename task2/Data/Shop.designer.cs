﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Shop")]
	public partial class ShopDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCustomer(Customer instance);
    partial void UpdateCustomer(Customer instance);
    partial void DeleteCustomer(Customer instance);
    partial void InsertProduct(Product instance);
    partial void UpdateProduct(Product instance);
    partial void DeleteProduct(Product instance);
    partial void InsertSale(Sale instance);
    partial void UpdateSale(Sale instance);
    partial void DeleteSale(Sale instance);
    partial void InsertSupply(Supply instance);
    partial void UpdateSupply(Supply instance);
    partial void DeleteSupply(Supply instance);
    #endregion
		
		public ShopDataContext() : 
				base(global::Data.Properties.Settings.Default.ShopConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ShopDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ShopDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ShopDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ShopDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Customer> Customers
		{
			get
			{
				return this.GetTable<Customer>();
			}
		}
		
		public System.Data.Linq.Table<Product> Products
		{
			get
			{
				return this.GetTable<Product>();
			}
		}
		
		public System.Data.Linq.Table<Sale> Sales
		{
			get
			{
				return this.GetTable<Sale>();
			}
		}
		
		public System.Data.Linq.Table<Supply> Supplies
		{
			get
			{
				return this.GetTable<Supply>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Customer")]
	public partial class Customer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _first_name;
		
		private string _last_name;
		
		private EntitySet<Sale> _Sales;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onfirst_nameChanging(string value);
    partial void Onfirst_nameChanged();
    partial void Onlast_nameChanging(string value);
    partial void Onlast_nameChanged();
    #endregion
		
		public Customer()
		{
			this._Sales = new EntitySet<Sale>(new Action<Sale>(this.attach_Sales), new Action<Sale>(this.detach_Sales));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_first_name", DbType="VarChar(50)")]
		public string first_name
		{
			get
			{
				return this._first_name;
			}
			set
			{
				if ((this._first_name != value))
				{
					this.Onfirst_nameChanging(value);
					this.SendPropertyChanging();
					this._first_name = value;
					this.SendPropertyChanged("first_name");
					this.Onfirst_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_last_name", DbType="VarChar(50)")]
		public string last_name
		{
			get
			{
				return this._last_name;
			}
			set
			{
				if ((this._last_name != value))
				{
					this.Onlast_nameChanging(value);
					this.SendPropertyChanging();
					this._last_name = value;
					this.SendPropertyChanged("last_name");
					this.Onlast_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Customer_Sale", Storage="_Sales", ThisKey="id", OtherKey="customer")]
		public EntitySet<Sale> Sales
		{
			get
			{
				return this._Sales;
			}
			set
			{
				this._Sales.Assign(value);
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
		
		private void attach_Sales(Sale entity)
		{
			this.SendPropertyChanging();
			entity.Customer1 = this;
		}
		
		private void detach_Sales(Sale entity)
		{
			this.SendPropertyChanging();
			entity.Customer1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Product")]
	public partial class Product : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _product_name;
		
		private System.Nullable<double> _price;
		
		private System.Nullable<int> _amount;
		
		private EntitySet<Sale> _Sales;
		
		private EntitySet<Supply> _Supplies;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onproduct_nameChanging(string value);
    partial void Onproduct_nameChanged();
    partial void OnpriceChanging(System.Nullable<double> value);
    partial void OnpriceChanged();
    partial void OnamountChanging(System.Nullable<int> value);
    partial void OnamountChanged();
    #endregion
		
		public Product()
		{
			this._Sales = new EntitySet<Sale>(new Action<Sale>(this.attach_Sales), new Action<Sale>(this.detach_Sales));
			this._Supplies = new EntitySet<Supply>(new Action<Supply>(this.attach_Supplies), new Action<Supply>(this.detach_Supplies));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_product_name", DbType="VarChar(50)")]
		public string product_name
		{
			get
			{
				return this._product_name;
			}
			set
			{
				if ((this._product_name != value))
				{
					this.Onproduct_nameChanging(value);
					this.SendPropertyChanging();
					this._product_name = value;
					this.SendPropertyChanged("product_name");
					this.Onproduct_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_price", DbType="Float")]
		public System.Nullable<double> price
		{
			get
			{
				return this._price;
			}
			set
			{
				if ((this._price != value))
				{
					this.OnpriceChanging(value);
					this.SendPropertyChanging();
					this._price = value;
					this.SendPropertyChanged("price");
					this.OnpriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_amount", DbType="Int")]
		public System.Nullable<int> amount
		{
			get
			{
				return this._amount;
			}
			set
			{
				if ((this._amount != value))
				{
					this.OnamountChanging(value);
					this.SendPropertyChanging();
					this._amount = value;
					this.SendPropertyChanged("amount");
					this.OnamountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_Sale", Storage="_Sales", ThisKey="id", OtherKey="product")]
		public EntitySet<Sale> Sales
		{
			get
			{
				return this._Sales;
			}
			set
			{
				this._Sales.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_Supply", Storage="_Supplies", ThisKey="id", OtherKey="product")]
		public EntitySet<Supply> Supplies
		{
			get
			{
				return this._Supplies;
			}
			set
			{
				this._Supplies.Assign(value);
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
		
		private void attach_Sales(Sale entity)
		{
			this.SendPropertyChanging();
			entity.Product1 = this;
		}
		
		private void detach_Sales(Sale entity)
		{
			this.SendPropertyChanging();
			entity.Product1 = null;
		}
		
		private void attach_Supplies(Supply entity)
		{
			this.SendPropertyChanging();
			entity.Product1 = this;
		}
		
		private void detach_Supplies(Supply entity)
		{
			this.SendPropertyChanging();
			entity.Product1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Sale")]
	public partial class Sale : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private System.DateTime _sale_time;
		
		private int _product;
		
		private int _product_amount;
		
		private int _customer;
		
		private EntityRef<Product> _Product1;
		
		private EntityRef<Customer> _Customer1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onsale_timeChanging(System.DateTime value);
    partial void Onsale_timeChanged();
    partial void OnproductChanging(int value);
    partial void OnproductChanged();
    partial void Onproduct_amountChanging(int value);
    partial void Onproduct_amountChanged();
    partial void OncustomerChanging(int value);
    partial void OncustomerChanged();
    #endregion
		
		public Sale()
		{
			this._Product1 = default(EntityRef<Product>);
			this._Customer1 = default(EntityRef<Customer>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sale_time", DbType="Date NOT NULL")]
		public System.DateTime sale_time
		{
			get
			{
				return this._sale_time;
			}
			set
			{
				if ((this._sale_time != value))
				{
					this.Onsale_timeChanging(value);
					this.SendPropertyChanging();
					this._sale_time = value;
					this.SendPropertyChanged("sale_time");
					this.Onsale_timeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_product", DbType="Int NOT NULL")]
		public int product
		{
			get
			{
				return this._product;
			}
			set
			{
				if ((this._product != value))
				{
					if (this._Product1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnproductChanging(value);
					this.SendPropertyChanging();
					this._product = value;
					this.SendPropertyChanged("product");
					this.OnproductChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_product_amount", DbType="Int NOT NULL")]
		public int product_amount
		{
			get
			{
				return this._product_amount;
			}
			set
			{
				if ((this._product_amount != value))
				{
					this.Onproduct_amountChanging(value);
					this.SendPropertyChanging();
					this._product_amount = value;
					this.SendPropertyChanged("product_amount");
					this.Onproduct_amountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_customer", DbType="Int NOT NULL")]
		public int customer
		{
			get
			{
				return this._customer;
			}
			set
			{
				if ((this._customer != value))
				{
					if (this._Customer1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OncustomerChanging(value);
					this.SendPropertyChanging();
					this._customer = value;
					this.SendPropertyChanged("customer");
					this.OncustomerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_Sale", Storage="_Product1", ThisKey="product", OtherKey="id", IsForeignKey=true)]
		public Product Product1
		{
			get
			{
				return this._Product1.Entity;
			}
			set
			{
				Product previousValue = this._Product1.Entity;
				if (((previousValue != value) 
							|| (this._Product1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Product1.Entity = null;
						previousValue.Sales.Remove(this);
					}
					this._Product1.Entity = value;
					if ((value != null))
					{
						value.Sales.Add(this);
						this._product = value.id;
					}
					else
					{
						this._product = default(int);
					}
					this.SendPropertyChanged("Product1");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Customer_Sale", Storage="_Customer1", ThisKey="customer", OtherKey="id", IsForeignKey=true)]
		public Customer Customer1
		{
			get
			{
				return this._Customer1.Entity;
			}
			set
			{
				Customer previousValue = this._Customer1.Entity;
				if (((previousValue != value) 
							|| (this._Customer1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Customer1.Entity = null;
						previousValue.Sales.Remove(this);
					}
					this._Customer1.Entity = value;
					if ((value != null))
					{
						value.Sales.Add(this);
						this._customer = value.id;
					}
					else
					{
						this._customer = default(int);
					}
					this.SendPropertyChanged("Customer1");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Supply")]
	public partial class Supply : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private System.DateTime _supply_time;
		
		private int _product;
		
		private int _product_amount;
		
		private EntityRef<Product> _Product1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onsupply_timeChanging(System.DateTime value);
    partial void Onsupply_timeChanged();
    partial void OnproductChanging(int value);
    partial void OnproductChanged();
    partial void Onproduct_amountChanging(int value);
    partial void Onproduct_amountChanged();
    #endregion
		
		public Supply()
		{
			this._Product1 = default(EntityRef<Product>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_supply_time", DbType="Date NOT NULL")]
		public System.DateTime supply_time
		{
			get
			{
				return this._supply_time;
			}
			set
			{
				if ((this._supply_time != value))
				{
					this.Onsupply_timeChanging(value);
					this.SendPropertyChanging();
					this._supply_time = value;
					this.SendPropertyChanged("supply_time");
					this.Onsupply_timeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_product", DbType="Int NOT NULL")]
		public int product
		{
			get
			{
				return this._product;
			}
			set
			{
				if ((this._product != value))
				{
					if (this._Product1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnproductChanging(value);
					this.SendPropertyChanging();
					this._product = value;
					this.SendPropertyChanged("product");
					this.OnproductChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_product_amount", DbType="Int NOT NULL")]
		public int product_amount
		{
			get
			{
				return this._product_amount;
			}
			set
			{
				if ((this._product_amount != value))
				{
					this.Onproduct_amountChanging(value);
					this.SendPropertyChanging();
					this._product_amount = value;
					this.SendPropertyChanged("product_amount");
					this.Onproduct_amountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_Supply", Storage="_Product1", ThisKey="product", OtherKey="id", IsForeignKey=true)]
		public Product Product1
		{
			get
			{
				return this._Product1.Entity;
			}
			set
			{
				Product previousValue = this._Product1.Entity;
				if (((previousValue != value) 
							|| (this._Product1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Product1.Entity = null;
						previousValue.Supplies.Remove(this);
					}
					this._Product1.Entity = value;
					if ((value != null))
					{
						value.Supplies.Add(this);
						this._product = value.id;
					}
					else
					{
						this._product = default(int);
					}
					this.SendPropertyChanged("Product1");
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
