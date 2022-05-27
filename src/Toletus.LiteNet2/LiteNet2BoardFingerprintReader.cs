﻿using System;
using System.Threading.Tasks;
using Toletus.SM25;
using Toletus.SM25.Command.Enums;

namespace Toletus.LiteNet2
{
    public partial class LiteNet2Board
    {
        public void CreateFingerprintReaderAndTest()
        {
            Task.Run(CreateFingerprintReader);
        }

        public SM25Reader CreateFingerprintReader()
        {
            FingerprintReader = new SM25Reader(Ip);
            FingerprintReader.OnConnectionStateChanged += FingerprintReaderConnectionStateChanged;

            FingerprintReader.TestFingerprintReaderConnection();

            return FingerprintReader;
        }

        private void FingerprintReaderConnectionStateChanged(ConnectionStatus connectionStatus)
        {
            if (connectionStatus == ConnectionStatus.Closed) return;

            try
            {
                if (!HasFingerprintReader && connectionStatus == ConnectionStatus.Connected)
                    HasFingerprintReader = true;

                //var ret = FingerprintReader.Sync.TestConnection();
                
                //HasFingerprintReader = (ret != null && ret.ReturnCode != ReturnCodes.ERR_UNDEFINED);

                //if (HasFingerprintReader) FingerprintReader.Sync.SetFingerTimeOut(60);
                //FingerprintReader.Close();
            }
            catch (Exception ex)
            {
                Logger.Debug($"{nameof(FingerprintReaderConnectionStateChanged)} Exception " + ex.Message);
                throw;
            }
            finally
            {
                FingerprintReader.OnConnectionStateChanged -= FingerprintReaderConnectionStateChanged;
                
                //while (FingerprintReader.Connected)
                //{
                //    FingerprintReader.Close();
                //    Thread.Sleep(100);
                //}
                OnFingerprintReaderConnected?.Invoke(HasFingerprintReader);
            }
        }
    }
}