//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// PBManager.cs (31/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Manager del componente Progress Bar							\\
// Fecha Mod:		31/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Manager del componente Progress Bar</para>
	/// </summary>
	public class PBManager : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para><see cref="Tipos"/> de PB que es.</para>
		/// </summary>
		public Tipos tipo;													// see cref="Tipos"/> de PB que es
		/// <summary>
		/// <para>Barra de progreso.</para>
		/// </summary>
		public Image bar;													// Barra de progreso
		/// <summary>
		/// <para>Texto de la barra de progreso</para>
		/// </summary>
		public Text textoBar;												// Texto de la barra de progreso
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Tiempo actual pasado.</para>
		/// </summary>
		private float tiempoActual;											// Tiempo actual pasado
		/// <summary>
		/// <para>Velocidad del conteo</para>
		/// </summary>
		private float velocidad  = 30.0f;									// Velocidad del conteo
		#endregion

		#region Variables Test (Borrar para Produccion)
		public string scene = string.Empty;
		#endregion

		#region Actualizador
		/// <summary>
		/// <para>Actualizador de PBManager</para>
		/// </summary>
		private void Update()// Actualizador de PBManager
		{
			switch (tipo)
			{
				case Tipos.Normal:
					#region Normal Core

					#endregion
					break;

				case Tipos.Radial:
					#region Radial Core
					// Si el tiempo pasado es menor a lo acordado
					if (tiempoActual < 100)
					{
						// Actualizar tiempo y texto del PB
						tiempoActual = tiempoActual + velocidad * Time.deltaTime;
						textoBar.text = tiempoActual.ToString("F0") + "%";
						Debug.Log(tiempoActual.ToString() + " % ...");
					}
					else
					{
						// Si el tiempo pasado es mayor al acordado, actualizar texto
						textoBar.text = "Completado";
						Debug.Log("Completado");

						// TODO Test (Borrar para produccion)
						StartCoroutine(SaltarEscena());
					}

					// Actualizar progress bar
					bar.fillAmount = tiempoActual / 100;
					#endregion
					break;

				case Tipos.Mascara:
					#region Mascara Core

					#endregion
					break;

				default:
					Debug.LogWarning("<color=yellow>[WAR]</color> La variable 'Tipo' tiene un valor desconocido.");
					break;
			}
		}

		#region Test (Borrar para Produccion)
		private IEnumerator SaltarEscena()
		{
			yield return new WaitForSeconds(1f);

			SceneManager.LoadScene(scene);
		}
		#endregion
		#endregion
	}

	/// <summary>
	/// <para>Tipos de Progress Bar</para>
	/// </summary>
	public enum Tipos
	{
		Radial,
		Normal,
		Mascara
	}
}
