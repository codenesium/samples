import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import SalesPersonMapper from './salesPersonMapper';
import SalesPersonViewModel from './salesPersonViewModel';

interface Props {
  model?: SalesPersonViewModel;
}

const SalesPersonDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="bonus" className={'col-sm-2 col-form-label'}>
          Bonus
        </label>
        <div className="col-sm-12">{String(model.model!.bonus)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="businessEntityID" className={'col-sm-2 col-form-label'}>
          BusinessEntityID
        </label>
        <div className="col-sm-12">{String(model.model!.businessEntityID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="commissionPct" className={'col-sm-2 col-form-label'}>
          CommissionPct
        </label>
        <div className="col-sm-12">{String(model.model!.commissionPct)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
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
        <label htmlFor="salesQuota" className={'col-sm-2 col-form-label'}>
          SalesQuota
        </label>
        <div className="col-sm-12">{String(model.model!.salesQuota)}</div>
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
  businessEntityID: number;
}

interface IMatch {
  params: IParams;
}

interface SalesPersonDetailComponentProps {
  match: IMatch;
}

interface SalesPersonDetailComponentState {
  model?: SalesPersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SalesPersonDetailComponent extends React.Component<
  SalesPersonDetailComponentProps,
  SalesPersonDetailComponentState
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
          'salespersons/' +
          this.props.match.params.businessEntityID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.SalesPersonClientResponseModel;

          let mapper = new SalesPersonMapper();

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
      return <SalesPersonDetailDisplay model={this.state.model} />;
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
    <Hash>45165f798f2b63096dd9695142cafa97</Hash>
</Codenesium>*/