using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Python.Runtime;

namespace OrderAcceptApp
{
    class KerasModel
    {
        private PyObject model;

        public KerasModel()
        {
            // Загрузка модели Python
            string modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "model.h5");
            if (!File.Exists(modelPath))
            {
                throw new FileNotFoundException("Model file not found.", modelPath);
            }

            // Загрузка Python
            using (Py.GIL())
            {
                PythonEngine.Initialize();
                // Загрузка Keras
                PyObject kerasModule = Py.Import("keras");
                // Загрузка модели
                if (kerasModule != null)
                {
                    // Получение атрибутов модуля
                    PyObject models = kerasModule.GetAttr("models");
                    // Здесь можно использовать models для загрузки модели и т.д.
                }
                else
                {
                    Console.WriteLine("Модуль keras не был загружен.");
                }
            }
        }
    }
}
