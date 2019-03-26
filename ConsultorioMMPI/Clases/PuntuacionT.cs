using ConsultorioMMPI.Clases.Escalas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultorioMMPI.Clases
{
    public static class PuntuacionT
    {
        public static void CalcularPuntuacionT(ref Escala escala)
        {

            #region arrays
            int[] arrayINVAR = new int[] { 29, 34, 38, 43, 48, 53, 58, 63, 68, 73, 78, 83, 88, 93, 98, 103, 108, 113, 118, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120 };
            int[] arrayINVER = new int[] { 111, 106, 100, 94, 88, 82, 77, 71, 65, 59, 53, 52, 58, 64, 70, 76, 81, 87, 93, 99, 105, 110, 116, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120 };

            int[] arrayFR = new int[] { 38, 41, 44, 46, 49, 52, 54, 57, 60, 62, 65, 67, 70, 73, 75, 78, 81, 83, 86, 88, 91, 94, 96, 99, 102, 104, 107, 110, 112, 115, 117, 120, 120 };
            int[] arrayFPSI = new int[] { 38, 43, 49, 55, 60, 66, 72, 77, 83, 89, 94, 100, 106, 111, 117, 120, 120, 120, 120, 120, 120, 120 };
            int[] arrayFS = new int[] { 38, 44, 49, 55, 61, 67, 73, 78, 84, 90, 96, 102, 107, 113, 119, 120, 120 };
            int[] arrayFVS = new int[] { 25, 28, 30, 33, 36, 38, 41, 44, 46, 49, 52, 54, 57, 60, 62, 65, 67, 70, 73, 75, 78, 81, 83, 86, 89, 91, 94, 97, 99, 102, 104 };
            int[] arraySI = new int[] { 24, 27, 31, 34, 37, 40, 44, 47, 50, 53, 57, 60, 63, 67, 70, 73, 76, 80, 83, 86, 89, 93, 96, 99, 102, 106, 109, 112, 115 };
            int[] arrayLR = new int[] { 26, 31, 35, 40, 45, 50, 54, 59, 64, 68, 73, 78, 83, 87, 92 };
            int[] arrayKR = new int[] { 24, 27, 31, 34, 38, 41, 45, 48, 52, 55, 59, 62, 66, 69, 73 };
            int[] arrayAEPI = new int[] { 30, 33, 35, 38, 40, 42, 44, 45, 47, 48, 49, 50, 51, 52, 53, 54, 55, 57, 58, 59, 61, 62, 64, 65, 67, 68, 70, 71, 73, 74, 76, 78, 79, 81, 82, 84, 85, 87, 88, 90, 91, 93 };
            int[] arrayAP = new int[] { 36, 41, 46, 50, 54, 57, 60, 62, 65, 67, 70, 73, 75, 78, 80, 83, 85, 88, 90, 93, 95, 98, 100, 100, 100, 100, 100 };
            int[] arrayACPE = new int[] { 28, 33, 37, 40, 44, 46, 49, 51, 54, 56, 59, 62, 65, 68, 72, 75, 78, 81, 84, 87, 90, 93, 96, 99 };
            int[] arrayCRD = new int[] { 35, 39, 43, 45, 48, 50, 51, 52, 53, 54, 55, 56, 58, 60, 62, 64, 66, 68, 71, 73, 15, 77, 79, 81, 84 };
            int[] arrayCR1 = new int[] { 32, 36, 39, 42, 45, 47, 50, 52, 54, 56, 58, 60, 63, 65, 67, 69, 71, 53, 76, 78, 80, 82, 84, 86, 88, 91, 93, 95 };
            int[] arrayCR2 = new int[] { 34, 38, 43, 47, 50, 54, 57, 60, 63, 66, 69, 72, 75, 78, 80, 83, 86, 89 };
            int[] arrayCR3 = new int[] { 31, 35, 38, 40, 42, 44, 46, 48, 51, 54, 58, 63, 68, 73, 78, 83 };
            int[] arrayCR4 = new int[] { 34, 39, 42, 46, 49, 51, 54, 57, 60, 64, 67, 70, 74, 77, 81, 84, 87, 91, 94, 98, 100, 100, 100 };
            int[] arrayCR6 = new int[] { 39, 48, 53, 57, 61, 64, 67, 71, 74, 78, 81, 84, 88, 91, 95, 98, 100, 100 };
            int[] arrayCR7 = new int[] { 32, 35, 38, 41, 43, 45, 47, 49, 51, 52, 54, 56, 58, 61, 63, 66, 68, 71, 73, 75, 78, 80, 83, 85, 88 };
            int[] arrayCR8 = new int[] { 35, 40, 44, 47, 50, 53, 56, 60, 64, 68, 71, 75, 79, 83, 87, 91, 95, 99, 100 };
            int[] arrayCR9 = new int[] { 25, 28, 30, 32, 34, 36, 38, 39, 40, 42, 43, 44, 46, 48, 50, 52, 54, 57, 60, 64, 67, 71, 74, 78, 82, 85, 89, 92, 96 };
            int[] arrayMAL = new int[] { 36, 42, 47, 52, 57, 63, 70, 77, 83 };
            int[] arrayQGI = new int[] { 43, 54, 60, 69, 79, 88 };
            int[] arrayQDC = new int[] { 40, 49, 53, 58, 65, 72, 79 };
            int[] arrayQNEU = new int[] { 38, 46, 51, 55, 61, 67, 73, 80, 86, 92, 99 };
            int[] arrayQCO = new int[] { 36, 42, 46, 49, 52, 55, 60, 66, 72, 78, 85 };
            int[] arrayISU = new int[] { 45, 64, 72, 79, 87, 94 };
            int[] arrayIMD = new int[] { 38, 50, 61, 70, 80, 89 };
            int[] arrayDSM = new int[] { 42, 52, 56, 65, 76 };
            int[] arrayINE = new int[] { 31, 37, 42, 45, 49, 53, 58, 64, 71, 77 };
            int[] arrayPE = new int[] { 34, 40, 45, 49, 54, 61, 69, 77 };
            int[] arrayANS = new int[] { 42, 54, 62, 71, 80, 90 };
            int[] arrayTEN = new int[] { 35, 42, 46, 49, 52, 58, 66, 76 };
            int[] arrayLCM = new int[] { 38, 46, 52, 58, 64, 71, 78, 84, 91, 98 };
            int[] arrayMEM = new int[] { 36, 43, 47, 51, 54, 59, 65, 71, 77, 82 };
            int[] arrayPCIJ = new int[] { 41, 51, 56, 64, 72, 80, 89 };
            int[] arrayABS = new int[] { 40, 50, 57, 64, 72, 79, 87, 94 };
            int[] arrayAG = new int[] { 35, 42, 47, 51, 56, 62, 68, 74, 81, 87 };
            int[] arrayEUF = new int[] { 33, 39, 43, 46, 51, 57, 66, 75, 85 };
            int[] arrayPFA = new int[] { 36, 43, 47, 51, 55, 59, 65, 70, 75, 80, 86 };
            int[] arrayPIP = new int[] { 37, 44, 50, 54, 58, 63, 68, 72, 77, 82, 86 };
            int[] arrayESO = new int[] { 34, 40, 45, 48, 50, 53, 57, 63, 69, 75, 81 };
            int[] arrayTIM = new int[] { 37, 43, 47, 49, 52, 57, 66, 75 };
            int[] arrayDES = new int[] { 42, 53, 60, 68, 76, 83, 91 };
            int[] arrayIEL = new int[] { 36, 42, 48, 54, 60, 66, 72, 78 };
            int[] arrayIFM = new int[] { 39, 44, 49, 54, 60, 65, 70, 75, 80, 85 };
            int[] arrayAGGR = new int[] { 22, 27, 30, 32, 34, 36, 38, 39, 40, 42, 45, 48, 52, 57, 63, 69, 75, 82, 88 };
            int[] arrayPSYC = new int[] { 35, 41, 45, 49, 53, 56, 59, 61, 64, 66, 69, 71, 74, 76, 79, 81, 84, 86, 89, 91, 100, 100, 100, 100, 100, 100, 100 };
            int[] arrayDISC = new int[] { 29, 34, 37, 41, 44, 46, 49, 52, 55, 58, 62, 66, 70, 73, 77, 81, 85, 89, 93, 97, 101 };
            int[] arrayNEGE = new int[] { 29, 33, 36, 38, 41, 43, 45, 47, 49, 52, 54, 57, 62, 64, 68, 72, 76, 80, 83, 87, 92 };
            int[] arrayINTR = new int[] { 29, 33, 37, 40, 43, 46, 49, 51, 54, 56, 59, 63, 66, 69, 72, 76, 79, 82, 86, 89, 89 };
            #endregion

            switch (escala.siglas)
            {
                #region Escalas de validez
                case "INVAR-R":
                    if (escala.puntuacionNatural > 19)
                        escala.puntuacionT = 120;
                    else
                        escala.puntuacionT = arrayINVAR[escala.puntuacionNatural];
                    escala.maximo = arrayINVAR[arrayINVAR.Count() - 1];
                    escala.minimo = arrayINVAR[0];
                    break;
                case "INVER-R":
                    if (escala.puntuacionNatural > 23)
                        escala.puntuacionT = 120;
                    else
                        escala.puntuacionT = arrayINVER[escala.puntuacionNatural];
                    escala.maximo = arrayINVER[arrayINVER.Count() - 1];
                    escala.minimo = arrayINVER[0];
                    break;
                case "F-R":
                    if (escala.puntuacionNatural > 31)
                        escala.puntuacionT = 120;
                    else
                        escala.puntuacionT = arrayFR[escala.puntuacionNatural];
                    escala.maximo = arrayFR[arrayFR.Count() - 1];
                    escala.minimo = arrayFR[0];
                    break;
                case "FPSI-R":
                    if (escala.puntuacionNatural > 15)
                        escala.puntuacionT = 120;
                    else
                        escala.puntuacionT = arrayFPSI[escala.puntuacionNatural];
                    escala.maximo = arrayFPSI[arrayFPSI.Count() - 1];
                    escala.minimo = arrayFPSI[0];
                    break;
                case "FS":
                    if (escala.puntuacionNatural > 15)
                        escala.puntuacionT = 120;
                    else
                        escala.puntuacionT = arrayFS[escala.puntuacionNatural];
                    escala.maximo = arrayFS[arrayFS.Count() - 1];
                    escala.minimo = arrayFS[0];
                    break;
                case "FVS-R":
                    if (escala.puntuacionNatural > 30)
                        escala.puntuacionT = 104;
                    else
                        escala.puntuacionT = arrayFVS[escala.puntuacionNatural];
                    escala.maximo = arrayFVS[arrayFVS.Count() - 1];
                    escala.minimo = arrayFVS[0];
                    break;
                case "SI":
                    if (escala.puntuacionNatural > 28)
                        escala.puntuacionT = 115;
                    else
                        escala.puntuacionT = arraySI[escala.puntuacionNatural];
                    escala.maximo = arraySI[arraySI.Count() - 1];
                    escala.minimo = arraySI[0];
                    break;
                case "L-R":
                    if (escala.puntuacionNatural > 14)
                        escala.puntuacionT = 92;
                    else
                        escala.puntuacionT = arrayLR[escala.puntuacionNatural];
                    escala.maximo = arrayLR[arrayLR.Count() - 1];
                    escala.minimo = arrayLR[0];
                    break;
                case "K-R":
                    if (escala.puntuacionNatural > 14)
                        escala.puntuacionT = 73;
                    else
                        escala.puntuacionT = arrayKR[escala.puntuacionNatural];
                    escala.maximo = arrayKR[arrayKR.Count() - 1];
                    escala.minimo = arrayKR[0];
                    break;

                #endregion
                #region Orden superior
                case "AE/PI":
                    if (escala.puntuacionNatural > 41)
                        escala.puntuacionT = 93;
                    else
                        escala.puntuacionT = arrayAEPI[escala.puntuacionNatural];
                    escala.maximo = arrayAEPI[arrayAEPI.Count() - 1];
                    escala.minimo = arrayAEPI[0];
                    break;
                case "AP":
                    if (escala.puntuacionNatural > 22)
                        escala.puntuacionT = 100;
                    else
                        escala.puntuacionT = arrayAP[escala.puntuacionNatural];
                    escala.maximo = arrayAP[arrayAP.Count() - 1];
                    escala.minimo = arrayAP[0];
                    break;
                case "AC/PE":
                    if (escala.puntuacionNatural > 23)
                        escala.puntuacionT = 99;
                    else
                        escala.puntuacionT = arrayACPE[escala.puntuacionNatural];
                    escala.maximo = arrayACPE[arrayACPE.Count() - 1];
                    escala.minimo = arrayACPE[0];
                    break;
                #endregion
                #region Clinicas Reestructuradas
                case "CRD":
                    if (escala.puntuacionNatural > 24)
                        escala.puntuacionT = 84;
                    else
                        escala.puntuacionT = arrayCRD[escala.puntuacionNatural];
                    escala.maximo = arrayCRD[arrayCRD.Count() - 1];
                    escala.minimo = arrayCRD[0];
                    break;
                case "CR1":
                    if (escala.puntuacionNatural > 27)
                        escala.puntuacionT = 95;
                    else
                        escala.puntuacionT = arrayCR1[escala.puntuacionNatural];
                    escala.maximo = arrayCR1[arrayCR1.Count() - 1];
                    escala.minimo = arrayCR1[0];
                    break;
                case "CR2":
                    if (escala.puntuacionNatural > 17)
                        escala.puntuacionT = 89;
                    else
                        escala.puntuacionT = arrayCR2[escala.puntuacionNatural];
                    escala.maximo = arrayCR2[arrayCR2.Count() - 1];
                    escala.minimo = arrayCR2[0];
                    break;
                case "CR3":
                    if (escala.puntuacionNatural > 15)
                        escala.puntuacionT = 83;
                    else
                        escala.puntuacionT = arrayCR3[escala.puntuacionNatural];
                    escala.maximo = arrayCR3[arrayCR3.Count() - 1];
                    escala.minimo = arrayCR3[0];
                    break;
                case "CR4":
                    if (escala.puntuacionNatural > 20)
                        escala.puntuacionT = 100;
                    else
                        escala.puntuacionT = arrayCR4[escala.puntuacionNatural];
                    escala.maximo = arrayCR4[arrayCR4.Count() - 1];
                    escala.minimo = arrayCR4[0];
                    break;
                case "CR6":
                    if (escala.puntuacionNatural > 16)
                        escala.puntuacionT = 100;
                    else
                        escala.puntuacionT = arrayCR6[escala.puntuacionNatural];
                    escala.maximo = arrayCR6[arrayCR6.Count() - 1];
                    escala.minimo = arrayCR6[0];
                    break;
                case "CR7":
                    if (escala.puntuacionNatural > 24)
                        escala.puntuacionT = 88;
                    else
                        escala.puntuacionT = arrayCR7[escala.puntuacionNatural];
                    escala.maximo = arrayCR7[arrayCR7.Count() - 1];
                    escala.minimo = arrayCR7[0];
                    break;
                case "CR8":
                    if (escala.puntuacionNatural > 18)
                        escala.puntuacionT = 100;
                    else
                        escala.puntuacionT = arrayCR8[escala.puntuacionNatural];
                    escala.maximo = arrayCR8[arrayCR8.Count() - 1];
                    escala.minimo = arrayCR8[0];
                    break;
                case "CR9":
                    if (escala.puntuacionNatural > 28)
                        escala.puntuacionT = 96;
                    else
                        escala.puntuacionT = arrayCR9[escala.puntuacionNatural];
                    escala.maximo = arrayCR9[arrayCR9.Count() - 1];
                    escala.minimo = arrayCR9[0];
                    break;
                #endregion
                #region Somaticas/Cognitivas
                case "MAL":
                    escala.puntuacionT = CalculaT(arrayMAL, escala.puntuacionNatural);
                    escala.maximo = arrayMAL[arrayMAL.Count() - 1];
                    escala.minimo = arrayMAL[0];
                    //escala.puntuacionT = arrayMAL[escala.puntuacionNatural];
                    break;
                case "QGI":
                    escala.puntuacionT = CalculaT(arrayQGI, escala.puntuacionNatural);
                    escala.maximo = arrayQGI[arrayQGI.Count() - 1];
                    escala.minimo = arrayQGI[0];
                    break;
                case "QDC":
                    escala.puntuacionT = CalculaT(arrayQDC, escala.puntuacionNatural);
                    escala.maximo = arrayQDC[arrayQDC.Count() - 1];
                    escala.minimo = arrayQDC[0];
                    break;
                case "QNEU":
                    escala.puntuacionT = CalculaT(arrayQNEU, escala.puntuacionNatural);
                    escala.maximo = arrayQNEU[arrayQNEU.Count() - 1];
                    escala.minimo = arrayQNEU[0];
                    break;
                case "QCO":
                    escala.puntuacionT = CalculaT(arrayQCO, escala.puntuacionNatural);
                    escala.maximo = arrayQCO[arrayQCO.Count() - 1];
                    escala.minimo = arrayQCO[0];
                    break;
                #endregion
                case "ISU":
                    escala.puntuacionT = CalculaT(arrayISU, escala.puntuacionNatural);
                    escala.maximo = arrayISU[arrayISU.Count() - 1];
                    escala.minimo = arrayISU[0];
                    break;
                case "LM/D":
                    escala.puntuacionT = CalculaT(arrayIMD, escala.puntuacionNatural);
                    escala.maximo = arrayIMD[arrayIMD.Count() - 1];
                    escala.minimo = arrayIMD[0];
                    break;
                case "DSM":
                    escala.puntuacionT = CalculaT(arrayDSM, escala.puntuacionNatural);
                    escala.maximo = arrayDSM[arrayDSM.Count() - 1];
                    escala.minimo = arrayDSM[0];
                    break;
                case "INE":
                    escala.puntuacionT = CalculaT(arrayINE, escala.puntuacionNatural);
                    escala.maximo = arrayINE[arrayINE.Count() - 1];
                    escala.minimo = arrayINE[0];
                    break;
                case "P/E":
                    escala.puntuacionT = CalculaT(arrayPE, escala.puntuacionNatural);
                    escala.maximo = arrayPE[arrayPE.Count() - 1];
                    escala.minimo = arrayPE[0];
                    break;
                case "ANS":
                    escala.puntuacionT = CalculaT(arrayANS, escala.puntuacionNatural);
                    escala.maximo = arrayANS[arrayANS.Count() - 1];
                    escala.minimo = arrayANS[0];
                    break;
                case "TEN":
                    escala.puntuacionT = CalculaT(arrayTEN, escala.puntuacionNatural);
                    escala.maximo = arrayTEN[arrayTEN.Count() - 1];
                    escala.minimo = arrayTEN[0];
                    break;
                case "LCM":
                    escala.puntuacionT = CalculaT(arrayLCM, escala.puntuacionNatural);
                    escala.maximo = arrayLCM[arrayLCM.Count() - 1];
                    escala.minimo = arrayLCM[0];
                    break;
                case "MEM":
                    escala.puntuacionT = CalculaT(arrayMEM, escala.puntuacionNatural);
                    escala.maximo = arrayMEM[arrayMEM.Count() - 1];
                    escala.minimo = arrayMEM[0];
                    break;
                case "PCIJ":
                    escala.puntuacionT = CalculaT(arrayPCIJ, escala.puntuacionNatural);
                    escala.maximo = arrayPCIJ[arrayPCIJ.Count() - 1];
                    escala.minimo = arrayPCIJ[0];
                    break;
                case "ABS":
                    escala.puntuacionT = CalculaT(arrayABS, escala.puntuacionNatural);
                    escala.maximo = arrayABS[arrayABS.Count() - 1];
                    escala.minimo = arrayABS[0];
                    break;
                case "AG":
                    escala.puntuacionT = CalculaT(arrayAG, escala.puntuacionNatural);
                    escala.maximo = arrayAG[arrayAG.Count() - 1];
                    escala.minimo = arrayAG[0];
                    break;
                case "EUF":
                    escala.puntuacionT = CalculaT(arrayEUF, escala.puntuacionNatural);
                    escala.maximo = arrayEUF[arrayEUF.Count() - 1];
                    escala.minimo = arrayEUF[0];
                    break;
                case "PFA":
                    escala.puntuacionT = CalculaT(arrayPFA, escala.puntuacionNatural);
                    escala.maximo = arrayPFA[arrayPFA.Count() - 1];
                    escala.minimo = arrayPFA[0];
                    break;
                case "PIP":
                    escala.puntuacionT = CalculaT(arrayPIP, escala.puntuacionNatural);
                    escala.maximo = arrayPIP[arrayPIP.Count() - 1];
                    escala.minimo = arrayPIP[0];
                    break;
                case "ESO":
                    escala.puntuacionT = CalculaT(arrayESO, escala.puntuacionNatural);
                    escala.maximo = arrayESO[arrayESO.Count() - 1];
                    escala.minimo = arrayESO[0];
                    break;
                case "TIM":
                    escala.puntuacionT = CalculaT(arrayTIM, escala.puntuacionNatural);
                    escala.maximo = arrayTIM[arrayTIM.Count() - 1];
                    escala.minimo = arrayTIM[0];
                    break;
                case "DES":
                    escala.puntuacionT = CalculaT(arrayDES, escala.puntuacionNatural);
                    escala.maximo = arrayDES[arrayDES.Count() - 1];
                    escala.minimo = arrayDES[0];
                    break;
                case "IEL":
                    escala.puntuacionT = CalculaT(arrayIEL, escala.puntuacionNatural);
                    escala.maximo = arrayIEL[arrayIEL.Count() - 1];
                    escala.minimo = arrayIEL[0];
                    break;
                case "IFM":
                    escala.puntuacionT = CalculaT(arrayIFM, escala.puntuacionNatural);
                    escala.maximo = arrayIFM[arrayIFM.Count() - 1];
                    escala.minimo = arrayIFM[0];
                    break;
                case "AGGR-R":
                    escala.puntuacionT = CalculaT(arrayAGGR, escala.puntuacionNatural);
                    escala.maximo = arrayAGGR[arrayAGGR.Count() - 1];
                    escala.minimo = arrayAGGR[0];
                    break;
                case "PSYC-R":
                    escala.puntuacionT = CalculaT(arrayPSYC, escala.puntuacionNatural);
                    escala.maximo = arrayPSYC[arrayPSYC.Count() - 1];
                    escala.minimo = arrayPSYC[0];
                    break;
                case "DISC-R":
                    escala.puntuacionT = CalculaT(arrayDISC, escala.puntuacionNatural);
                    escala.maximo = arrayDISC[arrayDISC.Count() - 1];
                    escala.minimo = arrayDISC[0];
                    break;
                case "NEGE-R":
                    escala.puntuacionT = CalculaT(arrayNEGE, escala.puntuacionNatural);
                    escala.maximo = arrayNEGE[arrayNEGE.Count() - 1];
                    escala.minimo = arrayNEGE[0];
                    break;
                case "INTR-R":
                    escala.puntuacionT = CalculaT(arrayINTR, escala.puntuacionNatural);
                    escala.maximo = arrayINTR[arrayINTR.Count() - 1];
                    escala.minimo = arrayINTR[0];
                    break;
                default:
                    escala.puntuacionT = 0;
                    break;
            };
        }

        private static int CalculaT(int[] array, int puntuacionNatural)
        {
            if (puntuacionNatural >= array.Length - 1)
                return array.Last();
            else
                return array[puntuacionNatural];
        }
    }
}
