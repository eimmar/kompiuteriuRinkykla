/**
 * @(#) OrderComputer.cs
 */
using System;
namespace Projektas.SistemosArchitekturosDiagrama.Models
{
	public class OrderComputer
	{
		double kaina;

        string pavadinimas;
		
		Computer a;
		
		OrderItem a1;
		
		public class VaizdoPlokste : Part
		{
			int RAMKiekisGB;

            string RAMAtmintiesTipas;
			
			int galingumas;
			
			double ilgis;
			
			int monitoriausJungciuSkaicius;
			
		}
		
		public class UzsakymoPreke
		{
			double kaina;

            string pavadinimas;

            string kodas;
			
			Projektas.SistemosArchitekturosDiagrama.Models.OrderComputer.Uzsakymas a;
			
			Part a1;
			
			OrderComputer a2;
			
		}
		
		public class Uzsakymas
		{
			Projektas.SistemosArchitekturosDiagrama.Models.OrderComputer.UzsakymoPreke a;
			
			Customer a1;
			
			double suma;
			
			Projektas.OrderStatus statusas;
			
			DateTime sukurimoData;

            DateTime redagavimoData;
			
		}
		
	}
	
}
