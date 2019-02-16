import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import ColumnSameAsFKTableMapper from './columnSameAsFKTableMapper';
import ColumnSameAsFKTableViewModel from './columnSameAsFKTableViewModel';

interface Props {
  history: any;
  model?: ColumnSameAsFKTableViewModel;
}

const ColumnSameAsFKTableDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.ColumnSameAsFKTables + '/edit/' + model.model!.id
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{String(model.model!.id)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="person" className={'col-sm-2 col-form-label'}>
          Person
        </label>
        <div className="col-sm-12">
          {model.model!.personNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="personId" className={'col-sm-2 col-form-label'}>
          PersonId
        </label>
        <div className="col-sm-12">
          {model.model!.personIdNavigation!.toDisplay()}
        </div>
      </div>
    </form>
  );
};

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface ColumnSameAsFKTableDetailComponentProps {
  match: IMatch;
  history: any;
}

interface ColumnSameAsFKTableDetailComponentState {
  model?: ColumnSameAsFKTableViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ColumnSameAsFKTableDetailComponent extends React.Component<
  ColumnSameAsFKTableDetailComponentProps,
  ColumnSameAsFKTableDetailComponentState
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
          ApiRoutes.ColumnSameAsFKTables +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ColumnSameAsFKTableClientResponseModel;

          let mapper = new ColumnSameAsFKTableMapper();

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
        <ColumnSameAsFKTableDetailDisplay
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
    <Hash>0bbe82ec69c54cb65ffce939236be320</Hash>
</Codenesium>*/