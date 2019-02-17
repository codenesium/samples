import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import BillOfMaterialMapper from './billOfMaterialMapper';
import BillOfMaterialViewModel from './billOfMaterialViewModel';

interface Props {
  history: any;
  model?: BillOfMaterialViewModel;
}

const BillOfMaterialDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.BillOfMaterials +
              '/edit/' +
              model.model!.billOfMaterialsID
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
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
  history: any;
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
        Constants.ApiEndpoint +
          ApiRoutes.BillOfMaterials +
          '/' +
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
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return (
        <BillOfMaterialDetailDisplay
          history={this.props.history}
          model={this.state.model}
        />
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>37f9a55df96c239881e692a703bd489d</Hash>
</Codenesium>*/