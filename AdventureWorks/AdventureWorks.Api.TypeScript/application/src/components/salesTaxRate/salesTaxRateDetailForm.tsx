import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import SalesTaxRateMapper from './salesTaxRateMapper';
import SalesTaxRateViewModel from './salesTaxRateViewModel';

interface Props {
  model?: SalesTaxRateViewModel;
}

const SalesTaxRateDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="name" className={'col-sm-2 col-form-label'}>
          Name
        </label>
        <div className="col-sm-12">{String(model.model!.name)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="rowguid" className={'col-sm-2 col-form-label'}>
          Rowguid
        </label>
        <div className="col-sm-12">{String(model.model!.rowguid)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="salesTaxRateID" className={'col-sm-2 col-form-label'}>
          SalesTaxRateID
        </label>
        <div className="col-sm-12">{String(model.model!.salesTaxRateID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="stateProvinceID" className={'col-sm-2 col-form-label'}>
          StateProvinceID
        </label>
        <div className="col-sm-12">{String(model.model!.stateProvinceID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="taxRate" className={'col-sm-2 col-form-label'}>
          TaxRate
        </label>
        <div className="col-sm-12">{String(model.model!.taxRate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="taxType" className={'col-sm-2 col-form-label'}>
          TaxType
        </label>
        <div className="col-sm-12">{String(model.model!.taxType)}</div>
      </div>
    </form>
  );
};

interface IParams {
  salesTaxRateID: number;
}

interface IMatch {
  params: IParams;
}

interface SalesTaxRateDetailComponentProps {
  match: IMatch;
}

interface SalesTaxRateDetailComponentState {
  model?: SalesTaxRateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SalesTaxRateDetailComponent extends React.Component<
  SalesTaxRateDetailComponentProps,
  SalesTaxRateDetailComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: false,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiUrl +
          'salestaxrates/' +
          this.props.match.params.salesTaxRateID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.SalesTaxRateClientResponseModel;

          let mapper = new SalesTaxRateMapper();

          console.log(response);

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }
  render() {
    if (this.state.loading) {
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <SalesTaxRateDetailDisplay model={this.state.model} />;
    } else if (this.state.errorOccurred) {
      return (
        <div className="alert alert-danger">{this.state.errorMessage}</div>
      );
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>3e35bbab39922208fa5d8ac12627e73f</Hash>
</Codenesium>*/