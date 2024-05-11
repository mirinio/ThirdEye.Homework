export interface PortfoliosSimulation {
  portfolios: Portfolio[];
  goal_percentiles: number[];
  wealth_returns: number[];
  percentiles: number[];
  scenarios: number;
  total_quarters: number;
  active_quarters: number;
}

export interface Portfolio {
  name: string;
  assets: PortfolioAsset[];
  rebalancing_frequency: number;
  cash_asset_class_name: string;
  portfolio_mgmt_fee: number;
  liquid: boolean;
  capital_gain_tax_rate: number,
  income_tax_rate: number;
  max_credit_fraction: number;
}


export interface PortfolioAsset {
  asset_class: string;
  initial_allocation: number;
  asset_mgmt_fee: number;
  initial_load_fee: number;
}