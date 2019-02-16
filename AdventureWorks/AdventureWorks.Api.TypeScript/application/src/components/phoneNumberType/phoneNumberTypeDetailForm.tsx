import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import PhoneNumberTypeMapper from './phoneNumberTypeMapper';
import PhoneNumberTypeViewModel from './phoneNumberTypeViewModel';

interface Props {
  model?: PhoneNumberTypeViewModel;
}

const PhoneNumberTypeDetailDisplay = (model: Props) => {
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
        <label
          htmlFor="phoneNumberTypeID"
          className={'col-sm-2 col-form-label'}
        >
          PhoneNumberTypeID
        </label>
        <div className="col-sm-12">
          {String(model.model!.phoneNumberTypeID)}
        </div>
      </div>
    </form>
  );
};

interface IParams {
  phoneNumberTypeID: number;
}

interface IMatch {
  params: IParams;
}

interface PhoneNumberTypeDetailComponentProps {
  match: IMatch;
}

interface PhoneNumberTypeDetailComponentState {
  model?: PhoneNumberTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PhoneNumberTypeDetailComponent extends React.Component<
  PhoneNumberTypeDetailComponentProps,
  PhoneNumberTypeDetailComponentState
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
          'phonenumbertypes/' +
          this.props.match.params.phoneNumberTypeID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.PhoneNumberTypeClientResponseModel;

          let mapper = new PhoneNumberTypeMapper();

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
      return <PhoneNumberTypeDetailDisplay model={this.state.model} />;
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
    <Hash>3c6e44876f930c6a07599b7d3fbec6d5</Hash>
</Codenesium>*/