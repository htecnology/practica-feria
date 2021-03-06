﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace practica_feria
{
    public partial class Form1 : Form
    {
        string ban= "c";
        SpeechSynthesizer leer = new SpeechSynthesizer();
        SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
        SpeechRecognitionEngine rec1 = new SpeechRecognitionEngine();
        public Form1()
        {
            InitializeComponent();
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            escucharmenu1();
        }
        public void escucharmenu()
        {
            leer.Rate = 0;
            leer.Volume = 100;
            leer.Speak(" Que deseas buscar ?");
            Choices lista = new Choices();
            lista.Add(new string[] { "alumno", "PROFESOR", "docente", "curso", "aula", "saske deseo buscar" });
            Grammar gramatica = new Grammar(new GrammarBuilder(lista));
            try
            {
                rec.SetInputToDefaultAudioDevice();
                rec.LoadGrammar(gramatica);
                rec.SpeechRecognized += reconocimiento;
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception el)
            {

                MessageBox.Show(el.Message); ;
            }
        }
        public void escucharmenu1()
        {
      
            Choices lista = new Choices();
            lista.Add(new string[] {  "saske deseo buscar un curso de la ug" });
            Grammar gramatica = new Grammar(new GrammarBuilder(lista));
            try
            {
                rec1.SetInputToDefaultAudioDevice();
                rec1.LoadGrammar(gramatica);
                rec1.SpeechRecognized += reconocimiento;
                rec1.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception el)
            {

                MessageBox.Show(el.Message); ;
            }
        }
        public void reconocimiento(object sender, SpeechRecognizedEventArgs e)
            {
            if (e.Result.Text == "saske deseo buscar un curso de la ug")
            {
                rec1.RecognizeAsyncStop();
                escucharmenu();
            }
                if (e.Result.Text == "alumno")
                {
                    alumno_bt.PerformClick();
                }
                else if (e.Result.Text == "docente" || e.Result.Text == "PROFESOR")
                {
                    docente_bt.PerformClick();

                }
                else if (e.Result.Text == "curso" || e.Result.Text == "aula")
                {
                    aula_bt.PerformClick();

                }
            
            }

        private void button1_Click(object sender, EventArgs e)
        {
            rec.RecognizeAsyncStop();
            ventalumno nueva_venta = new ventalumno();
            nueva_venta.Show();
            this.Hide();
        }

        private void docente_bt_Click(object sender, EventArgs e)
        {
            rec.RecognizeAsyncStop();
            horainicio_text nueva_ventana = new horainicio_text();
            nueva_ventana.Show();
            this.Hide();
        }

        private void aula_bt_Click(object sender, EventArgs e)
        {
            rec.RecognizeAsyncStop();
            Aula nueva_ventana = new Aula();
            nueva_ventana.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

