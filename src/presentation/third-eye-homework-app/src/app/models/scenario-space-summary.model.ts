export interface ScenarioSpaceSummary {
  asset_classes: AssetClasses;
  inflation: Inflation;
}

export interface Returns {
  kurtosis: number;
  mean: number;
  skewness: number;
  standard_deviation: number;
}

export interface AssetClass {
  returns: Returns;
}

export interface AssetClasses {
  [key: string]: AssetClass;
}

interface Inflation {
  kurtosis: number;
  mean: number;
  skewness: number;
  standard_deviation: number;
}