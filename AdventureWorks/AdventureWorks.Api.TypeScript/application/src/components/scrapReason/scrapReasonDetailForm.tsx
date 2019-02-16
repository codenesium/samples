import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import ScrapReasonMapper from './scrapReasonMapper';
import ScrapReasonViewModel from './scrapReasonViewModel';

interface Props {
  model?: ScrapReasonViewModel;
}

const ScrapReasonDetailDisplay = (model: Props) => {
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
        <label htmlFor="scrapReasonID" className={'col-sm-2 col-form-label'}>
          ScrapReasonID
        </label>
        <div className="col-sm-12">{String(model.model!.scrapReasonID)}</div>
      </div>
    </form>
  );
};

interface IParams {
  scrapReasonID: number;
}

interface IMatch {
  params: IParams;
}

interface ScrapReasonDetailComponentProps {
  match: IMatch;
}

interface ScrapReasonDetailComponentState {
  model?: ScrapReasonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ScrapReasonDetailComponent extends React.Component<
  ScrapReasonDetailComponentProps,
  ScrapReasonDetailComponentState
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
          'scrapreasons/' +
          this.props.match.params.scrapReasonID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ScrapReasonClientResponseModel;

          let mapper = new ScrapReasonMapper();

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
      return <ScrapReasonDetailDisplay model={this.state.model} />;
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
    <Hash>bd6ae883962563a4fe4e310b03a42168</Hash>
</Codenesium>*/