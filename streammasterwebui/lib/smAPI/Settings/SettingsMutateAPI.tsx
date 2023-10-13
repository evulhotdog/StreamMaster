/* eslint unused-imports/no-unused-imports-ts: off */
/* eslint @typescript-eslint/no-unused-vars: off */
import type * as iptv from '@lib/iptvApi';
import { invokeHubConnection } from '@lib/signalr/signalr';

export const UpdateSetting = async (arg: iptv.UpdateSettingRequest): Promise<void | null> => {
  await invokeHubConnection<void>('UpdateSetting', arg);
};
