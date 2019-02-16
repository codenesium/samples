import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import IllustrationMapper from './illustrationMapper';
import IllustrationViewModel from './illustrationViewModel';

interface Props {
  model?: IllustrationViewModel;
}

const IllustrationDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="diagram" className={'col-sm-2 col-form-label'}>
          Diagram
        </label>
        <div className="col-sm-12">{String(model.model!.diagram)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="illustrationID" className={'col-sm-2 col-form-label'}>
          IllustrationID
        </label>
        <div className="col-sm-12">{String(model.model!.illustrationID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>
    </form>
  );
};

interface IParams {
  illustrationID: number;
}

interface IMatch {
  params: IParams;
}

interface IllustrationDetailComponentProps {
  match: IMatch;
}

interface IllustrationDetailComponentState {
  model?: IllustrationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class IllustrationDetailComponent extends React.Component<
  IllustrationDetailComponentProps,
  IllustrationDetailComponentState
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
          'illustrations/' +
          this.props.match.params.illustrationID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.IllustrationClientResponseModel;

          let mapper = new IllustrationMapper();

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
      return <IllustrationDetailDisplay model={this.state.model} />;
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
    <Hash>0ca256713546788432604d189d5aa584</Hash>
</Codenesium>*/