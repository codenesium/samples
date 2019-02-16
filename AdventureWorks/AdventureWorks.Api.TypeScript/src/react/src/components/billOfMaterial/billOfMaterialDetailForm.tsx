import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import BillOfMaterialMapper from './billOfMaterialMapper';
import BillOfMaterialViewModel from './billOfMaterialViewModel';

interface Props {
  model?: BillOfMaterialViewModel;
}

const BillOfMaterialDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label
          htmlFor="billOfMaterialsID"
          className={'col-sm-2 col-form-label'}
        >
          BillOfMaterialsID
        </label>
        <div className="col-sm-12">
          {String(model.model!.billOfMaterialsID)}
        </div>
      </div>

      <div className="form-group row">
        <label htmlFor="bOMLevel" className={'col-sm-2 col-form-label'}>
          BOMLevel
        </label>
        <div className="col-sm-12">{String(model.model!.bOMLevel)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="componentID" className={'col-sm-2 col-form-label'}>
          ComponentID
        </label>
        <div className="col-sm-12">{String(model.model!.componentID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="endDate" className={'col-sm-2 col-form-label'}>
          EndDate
        </label>
        <div className="col-sm-12">{String(model.model!.endDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="perAssemblyQty" className={'col-sm-2 col-form-label'}>
          PerAssemblyQty
        </label>
        <div className="col-sm-12">{String(model.model!.perAssemblyQty)}</div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="productAssemblyID"
          className={'col-sm-2 col-form-label'}
        >
          ProductAssemblyID
        </label>
        <div className="col-sm-12">
          {String(model.model!.productAssemblyID)}
        </div>
      </div>

      <div className="form-group row">
        <label htmlFor="startDate" className={'col-sm-2 col-form-label'}>
          StartDate
        </label>
        <div className="col-sm-12">{String(model.model!.startDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="unitMeasureCode" className={'col-sm-2 col-form-label'}>
          UnitMeasureCode
        </label>
        <div className="col-sm-12">{String(model.model!.unitMeasureCode)}</div>
      </div>
    </form>
  );
};

interface IParams {
  billOfMaterialsID: number;
}

interface IMatch {
  params: IParams;
}

interface BillOfMaterialDetailComponentProps {
  match: IMatch;
}

interface BillOfMaterialDetailComponentState {
  model?: BillOfMaterialViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class BillOfMaterialDetailComponent extends React.Component<
  BillOfMaterialDetailComponentProps,
  BillOfMaterialDetailComponentState
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
          'billofmaterials/' +
          this.props.match.params.billOfMaterialsID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.BillOfMaterialClientResponseModel;

          let mapper = new BillOfMaterialMapper();

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
      return <BillOfMaterialDetailDisplay model={this.state.model} />;
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
    <Hash>c2af291801381fb0334ff03b90948585</Hash>
</Codenesium>*/