import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import TagMapper from './tagMapper';
import TagViewModel from './tagViewModel';

interface Props {
  history: any;
  model?: TagViewModel;
}

const TagDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(ClientRoutes.Tags + '/edit/' + model.model!.id);
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="count" className={'col-sm-2 col-form-label'}>
          Count
        </label>
        <div className="col-sm-12">{String(model.model!.count)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="excerptPostId" className={'col-sm-2 col-form-label'}>
          ExcerptPostId
        </label>
        <div className="col-sm-12">{String(model.model!.excerptPostId)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="tagName" className={'col-sm-2 col-form-label'}>
          TagName
        </label>
        <div className="col-sm-12">{String(model.model!.tagName)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="wikiPostId" className={'col-sm-2 col-form-label'}>
          WikiPostId
        </label>
        <div className="col-sm-12">{String(model.model!.wikiPostId)}</div>
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

interface TagDetailComponentProps {
  match: IMatch;
  history: any;
}

interface TagDetailComponentState {
  model?: TagViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class TagDetailComponent extends React.Component<
  TagDetailComponentProps,
  TagDetailComponentState
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
          ApiRoutes.Tags +
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
          let response = resp.data as Api.TagClientResponseModel;

          let mapper = new TagMapper();

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
        <TagDetailDisplay
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
    <Hash>99fdd72f3b081cb4c9079612f317d546</Hash>
</Codenesium>*/