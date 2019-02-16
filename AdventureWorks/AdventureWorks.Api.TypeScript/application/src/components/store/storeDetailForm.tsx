import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import StoreMapper from './storeMapper';
import StoreViewModel from './storeViewModel';

interface Props {
  model?: StoreViewModel;
}

const StoreDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="businessEntityID" className={'col-sm-2 col-form-label'}>
          BusinessEntityID
        </label>
        <div className="col-sm-12">{String(model.model!.businessEntityID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="demographic" className={'col-sm-2 col-form-label'}>
          Demographics
        </label>
        <div className="col-sm-12">{String(model.model!.demographic)}</div>
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
        <label htmlFor="salesPersonID" className={'col-sm-2 col-form-label'}>
          SalesPersonID
        </label>
        <div className="col-sm-12">{String(model.model!.salesPersonID)}</div>
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

interface StoreDetailComponentProps {
  match: IMatch;
}

interface StoreDetailComponentState {
  model?: StoreViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class StoreDetailComponent extends React.Component<
  StoreDetailComponentProps,
  StoreDetailComponentState
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
        Constants.ApiUrl + 'stores/' + this.props.match.params.businessEntityID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.StoreClientResponseModel;

          let mapper = new StoreMapper();

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
      return <StoreDetailDisplay model={this.state.model} />;
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
    <Hash>5235e1f6240743c41423549016c04bf5</Hash>
</Codenesium>*/