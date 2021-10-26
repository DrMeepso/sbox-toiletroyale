using Sandbox;

namespace ToiletRoyale
{
	public class ClothingEntity : ModelEntity { }

	public partial class ToiletRoyalePlayer
	{
		public bool IsDressed = false;

		public ClothingEntity Hat;
		public ClothingEntity Jacket;
		public ClothingEntity Shoes;

		public virtual void DressPlayer()
		{
			if ( IsDressed ) return;

			DressEntity( ref Hat, GetRandomHat() );
			DressEntity( ref Jacket, GetRandomJacket() );
			DressEntity( ref Shoes, GetRandomShoes() );

			IsDressed = true;
		}

		/// <summary>
		/// This is the wrong way to do it, but OK for now
		/// </summary>
		public virtual void DressEntity( ref ClothingEntity clothingEntity, string model )
		{
			if ( clothingEntity != null ) clothingEntity.Delete();

			clothingEntity = new ClothingEntity();
			clothingEntity.Tags.Add( "clothes" );
			clothingEntity.SetModel( model );
			clothingEntity.SetParent( this, true );
			clothingEntity.EnableDrawing = true;
			clothingEntity.EnableShadowInFirstPerson = true;
			clothingEntity.EnableHideInFirstPerson = true;
		}

		public virtual string GetRandomHat()
		{
			string[] hats = new string[]
			{
				"",
				"models/citizen_clothes/hair/hair_looseblonde/hair_looseblonde.vmdl",
				"models/citizen_clothes/hair/hair_malestyle02.vmdl",
				"models/citizen_clothes/hat/hat.tophat.vmdl",
				"models/citizen_clothes/hat/hat_beret.black.vmdl",
				"models/citizen_clothes/hat/hat_cap.vmdl",
				"models/citizen_clothes/hat/hat_hardhat.vmdl",
				"models/citizen_clothes/hat/hat_leathercap.vmdl",
				"models/citizen_clothes/hat/hat_leathercapnobadge.vmdl",
				"models/citizen_clothes/hat/hat_securityhelmet.vmdl",
				"models/citizen_clothes/hat/hat_securityhelmetnostrap.vmdl",
				"models/citizen_clothes/hat/hat_service.vmdl",
				"models/citizen_clothes/hat/hat_uniform.police.vmdl",
				"models/citizen_clothes/hat/hat_woolly.vmdl",
				"models/citizen_clothes/hat/hat_woollybobble.vmdl"
			};

			return Rand.FromArray( hats );
		}

		public virtual string GetRandomJacket()
		{
			string[] jackets = new string[]
			{
				"",
				"models/citizen_clothes/jacket/SuitJacket/suitjacket.vmdl",
				"models/citizen_clothes/jacket/jacket.red.vmdl",
				"models/citizen_clothes/jacket/jacket.tuxedo.vmdl",
				"models/citizen_clothes/shirt/shirt_longsleeve.plain.vmdl",
				"models/citizen_clothes/shirt/shirt_longsleeve.police.vmdl",
				"models/citizen_clothes/shirt/shirt_longsleeve.scientist.vmdl"
			};

			return Rand.FromArray( jackets );
		}

		public virtual string GetRandomShoes()
		{
			string[] shoes = new string[]
			{
				"",
				"models/citizen_clothes/shoes/SmartShoes/smartshoes.vmdl",
				"models/citizen_clothes/shoes/shoes.police.vmdl",
				"models/citizen_clothes/shoes/shoes.workboots.vmdl",
				"models/citizen_clothes/shoes/trainers.vmdl"
			};

			return Rand.FromArray( shoes );
		}
	}
}
