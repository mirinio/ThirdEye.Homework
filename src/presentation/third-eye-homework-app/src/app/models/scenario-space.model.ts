export interface ScenarioSpace {
  id: string;
  name: string;
  assetClassCashType: AssetClassCashType;
}

export enum AssetClassCashType {
  CS_EUR = 'CS_EUR',
  CS_CHF = 'CS_CHF',
  CS_USD = 'CS_USD',
}