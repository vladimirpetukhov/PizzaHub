export interface ErrorResponse {
  type: string;
  title: string;
  status: number;
  traceId: string;
  errors: {
    [fieldName: string]: string[];
  };
}
