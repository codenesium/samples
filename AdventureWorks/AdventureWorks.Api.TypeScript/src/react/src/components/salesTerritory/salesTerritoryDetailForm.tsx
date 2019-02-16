import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import SalesTerritoryMapper from './salesTerritoryMapper';
import SalesTerritoryViewModel from './salesTerritoryViewModel';

interface Props {
  model?: SalesTerritoryViewModel;
}

const SalesTerritoryDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="costLastYear" className={'col-sm-2 col-form-label'}>
          CostLastYear
        </label>
        <div className="col-sm-12">{String(model.model!.costLastYear)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="costYTD" className={'col-sm-2 col-form-label'}>
          CostYTD
        </label>
        <div className="col-sm-12">{String(model.model!.costYTD)}</div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="countryRegionCode"
          className={'col-sm-2 col-form-label'}
        >
          CountryRegionCode
        </label>
        <div className="col-sm-12">
          {String(model.model!.countryRegionCode)}
        </div>
      </div>

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
        <label htmlFor="salesLastYear" className={'col-sm-2 col-form-label'}>
          SalesLastYear
        </label>
        <div className="col-sm-12">{String(model.model!.salesLastYear)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="salesYTD" className={'col-sm-2 col-form-label'}>
          SalesYTD
        </label>
        <div className="col-sm-12">{String(model.model!.salesYTD)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="territoryID" className={'col-sm-2 col-form-label'}>
          TerritoryID
        </label>
        <div className="col-sm-12">{String(model.model!.territoryID)}</div>
      </div>
    </form>
  );
};

interface IParams {
  territoryID: number;
}

interface IMatch {
  params: IParams;
}

interface SalesTerritoryDetailComponentProps {
  match: IMatch;
}

interface SalesTerritoryDetailComponentState {
  model?: SalesTerritoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SalesTerritoryDetailComponent extends React.Component<
  SalesTerritoryDetailComponentProps,
  SalesTerritoryDetailComponentState
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
          'salesterritories/' +
          this.props.match.params.territoryID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.SalesTerritoryClientResponseModel;

          let mapper = new SalesTerritoryMapper();

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
      return <SalesTerritoryDetailDisplay model={this.state.model} />;
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
    <Hash>54da91d7c7769576263ef898887c55ad</Hash>
</Codenesium>*/